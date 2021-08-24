SET TRANSACTION READ WRITE;
-- 
START TRANSACTION;
-- Office's FUNCTIONS -------------------------------------------------------
CREATE OR REPLACE FUNCTION GET_PAGINATED_OFFICE
(
    P_SearchValue VARCHAR DEFAULT NULL,
    P_ValueNo INT DEFAULT 0,
    P_PageSize INT DEFAULT 10,
    P_SortColumn INT DEFAULT 0,
    P_SortDirection VARCHAR DEFAULT 'ASC'
)
RETURNS TABLE
(
    RowNumber BIGINT,
    FilteredCount BIGINT,
    TotalCount INT,
    Id CHAR,
    Name VARCHAR,
    Note VARCHAR,
    FatherId CHAR,
    Active BOOLEAN,
    Rating DECIMAL
)
AS
$$
    DECLARE
        V_TotalCount INT;
        V_FirstRecord INT;
        V_LastRecord INT;
        V_SearchValue VARCHAR;
    BEGIN
        SELECT COUNT(*) INTO V_TotalCount FROM Office;
        V_FirstRecord := P_ValueNo + 1;
        V_LastRecord := P_ValueNo + P_PageSize;
        V_SearchValue := LTRIM(RTRIM(P_SearchValue));

        RETURN QUERY
            WITH CTE_RESULTS AS
            (
                SELECT ROW_NUMBER()
                OVER(
                    ORDER BY
                        CASE WHEN (P_SortColumn = 0 AND P_SortDirection = 'asc')
                            THEN Office.Id
                        END ASC,
                        CASE WHEN (P_SortColumn = 0 AND P_SortDirection = 'desc')
                            THEN Office.Id
                        END DESC,
                        CASE WHEN (P_SortColumn = 1 AND P_SortDirection = 'asc')
                            THEN Office.Name
                        END ASC,
                        CASE WHEN (P_SortColumn = 1 AND P_SortDirection = 'desc')
                            THEN Office.Name
                        END DESC,
                        CASE WHEN (P_SortColumn = 2 AND P_SortDirection = 'asc')
                            THEN Office.Note
                        END ASC,
                        CASE WHEN (P_SortColumn = 2 AND P_SortDirection = 'desc')
                            THEN Office.Note
                        END DESC,
                        CASE WHEN (P_SortColumn = 3 AND P_SortDirection = 'asc')
                            THEN Office.FatherId
                        END ASC,
                        CASE WHEN (P_SortColumn = 3 AND P_SortDirection = 'desc')
                            THEN Office.FatherId
                        END DESC,
                        CASE WHEN (P_SortColumn = 4 AND P_SortDirection = 'asc')
                            THEN Office.Active
                        END ASC,
                        CASE WHEN (P_SortColumn = 4 AND P_SortDirection = 'desc')
                            THEN Office.Active
                        END DESC,
                        CASE WHEN (P_SortColumn = 5 AND P_SortDirection = 'asc')
                            THEN Office.CreatedAt
                        END ASC,
                        CASE WHEN (P_SortColumn = 5 AND P_SortDirection = 'desc')
                            THEN Office.CreatedAt
                        END DESC,
                        CASE WHEN (P_SortColumn = 6 AND P_SortDirection = 'asc')
                            THEN Office.UpdatedAt
                        END ASC,
                        CASE WHEN (P_SortColumn = 6 AND P_SortDirection = 'desc')
                            THEN Office.UpdatedAt
                        END DESC
                )
                AS RowNumber,
                COUNT(*) OVER() AS FilteredCount,
                V_TotalCount AS TotalCount,
                Office.Id,
                Office.Name,
                Office.Note,
                Office.FatherId,
                Office.Active,
                Office.Rating
            FROM Office
            WHERE COALESCE(V_SearchValue, '') = ''
            OR UPPER(Office.Name) LIKE UPPER('%' || V_SearchValue || '%')
            )

            SELECT 
                CTE_RESULTS.RowNumber,
                CTE_RESULTS.FilteredCount,
                CTE_RESULTS.TotalCount,
                CTE_RESULTS.Id,
                CTE_RESULTS.Name,
                CTE_RESULTS.Note,
                CTE_RESULTS.FatherId,
                CTE_RESULTS.Active,
                CTE_RESULTS.Rating
            FROM CTE_RESULTS WHERE CTE_RESULTS.RowNumber BETWEEN V_FirstRecord AND V_LastRecord;
    END
$$
LANGUAGE PLPGSQL;
-- 
CREATE OR REPLACE FUNCTION GET_OFFICE_COUNT()
RETURNS BIGINT
AS
$$
    DECLARE
        Count BIGINT;
    BEGIN
        Count := (SELECT COUNT(*) FROM Office);
        RETURN Count;
    END
$$
LANGUAGE PLPGSQL;
-- 
CREATE OR REPLACE FUNCTION GET_ALL_OFFICE()
RETURNS TABLE
(
    Id CHAR,
    Name VARCHAR,
    Note VARCHAR,
    FatherId CHAR,
    Active BOOLEAN,
    Rating DECIMAL
)
AS
$$
    BEGIN
        RETURN QUERY
            SELECT
                Office.Id,
                Office.Name,
                Office.Note,
                Office.FatherId,
                Office.Active,
                Office.Rating
            FROM Office ORDER BY Office.Id;
    END
$$
LANGUAGE PLPGSQL;
-- 
CREATE OR REPLACE FUNCTION GET_OFFICE
(
    P_Id CHAR
)
RETURNS TABLE
(
    Id CHAR,
    Name VARCHAR,
    Note VARCHAR,
    FatherId CHAR,
    Active BOOLEAN,
    Rating DECIMAL,
    CreatedAt TIMESTAMP,
    UpdatedAt TIMESTAMP
)
AS
$$
    BEGIN
        RETURN QUERY
            SELECT 
                Office.Id,
                Office.Name,
                Office.Note,
                Office.FatherId,
                Office.Active,
                Office.Rating,
                Office.CreatedAt,
                Office.UpdatedAt
            FROM Office WHERE Office.Id = P_Id;
    END
$$
LANGUAGE PLPGSQL;
------------------------------------------------------------------------
COMMIT;