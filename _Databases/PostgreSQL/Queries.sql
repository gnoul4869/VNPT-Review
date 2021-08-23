SET TIMEZONE='Asia/Bangkok'
-- 
CREATE TABLE Office (
    Id CHAR(5),
    Name VARCHAR(50),
    Note VARCHAR(200),
    FatherId CHAR(5),
    Active BOOLEAN,
    Rating DECIMAL(2,1) DEFAULT 0,
    CreatedAt TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    UpdatedAt TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    -- 
    PRIMARY KEY (Id)
);
-- 
CREATE TABLE Review (
    Id CHAR(64),
    UserId VARCHAR(450),
    OfficeId CHAR(5),
    Rating DECIMAL(2,1),
    Content VARCHAR(200),
    CreatedAt TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    UpdatedAt TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    --
    PRIMARY KEY (Id),
    CONSTRAINT FK_ID
        FOREIGN KEY (OfficeId) REFERENCES Office (Id) ON DELETE CASCADE,
    CONSTRAINT FK_USERNAME
        FOREIGN KEY (UserId) REFERENCES "AspNetUsers" ("Id") ON DELETE CASCADE
);
-- SEQUENCES ----------------------------------------------------------------
CREATE SEQUENCE REVIEW_SEQ
    MINVALUE 1
    START WITH 1
    INCREMENT BY 1;
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
-- Office's PROCEDURES ------------------------------------------------------
CREATE OR REPLACE PROCEDURE UPDATE_OFFICE_RATING
(
    P_Id CHAR
)
AS
$$
    DECLARE
        X RECORD;
        V_Rate DECIMAL(16,1) DEFAULT 0;
        V_Sum DECIMAL(16,1) DEFAULT 0;
    BEGIN
        FOR X IN (SELECT Rating FROM Review Where Review.OfficeId = P_Id)
        LOOP
            V_Rate := V_Rate + X.Rating;
            V_Sum := V_Sum + 1;
        END LOOP;

        V_Rate := NVL(V_Rate / NULLIF(V_Sum,0),0);
        UPDATE Office SET Rating = V_Rate WHERE Id = P_Id;
    END
$$
LANGUAGE PLPGSQL;
-- 
CREATE OR REPLACE PROCEDURE CREATE_OFFICE
(
    P_Id CHAR,
    P_Name VARCHAR,
    P_Note VARCHAR,
    P_FatherId CHAR,
    P_Active BOOLEAN
)
AS
$$
    BEGIN
        INSERT INTO Office VALUES
        (
            P_Id,
            P_Name,
            P_Note,
            P_FatherId,
            P_Active,
            DEFAULT,
            DEFAULT,
            DEFAULT
        );
    END
$$
LANGUAGE PLPGSQL;
-- 
CREATE OR REPLACE PROCEDURE UPDATE_OFFICE
(
    P_Id CHAR,
    P_Name VARCHAR,
    P_Note VARCHAR,
    P_FatherId CHAR,
    P_Active BOOLEAN
)
AS
$$
    BEGIN
        UPDATE Office SET
            Name = P_Name,
            Note = P_Note,
            FatherId = P_FatherId,
            Active = P_Active,
            UpdatedAt = DEFAULT
        WHERE Id = P_Id; 
    END
$$
LANGUAGE PLPGSQL;
-- 
CREATE OR REPLACE PROCEDURE DELETE_OFFICE
(
    P_Id CHAR
)
AS
$$
    BEGIN
        DELETE FROM Office WHERE
            Id = P_Id;
    END
$$
LANGUAGE PLPGSQL;
-- Review's FUNCTION --------------------------------------------------------
CREATE OR REPLACE FUNCTION EXIST_USER_REVIEW_IN_OFFICE
(
    P_UserId VARCHAR,
    P_OfficeId CHAR
)
RETURNS INT
AS
$$
    DECLARE
        Exist INT;
    BEGIN
        Exist := (SELECT COUNT(1) FROM Review WHERE Review.UserId = P_UserId AND Review.OfficeId = P_OfficeId);
        RETURN Exist;
    END
$$
LANGUAGE PLPGSQL;
-- 
CREATE OR REPLACE FUNCTION GET_REVIEW_COUNT_IN_OFFICE
(
    P_OfficeId CHAR
)
RETURNS BIGINT
AS
$$
    DECLARE
        Count BIGINT;
    BEGIN
        Count := (SELECT COUNT(*) FROM Review WHERE Review.OfficeId = P_OfficeId);
        RETURN Count;
    END
$$
LANGUAGE PLPGSQL;
-- 
CREATE OR REPLACE FUNCTION GET_INFINITE_REVIEW_IN_OFFICE
(
    P_Id CHAR,
    P_Value INT DEFAULT 4
)
RETURNS TABLE
(
    Id CHAR,
    UserName VARCHAR,
    OfficeId CHAR,
    Rating DECIMAL,
    Content VARCHAR,
    CreatedAt TIMESTAMP,
    UpdatedAT TIMESTAMP
)
AS
$$
    BEGIN
        RETURN QUERY
            SELECT DISTINCT Review.Id, "AspNetUsers"."UserName", Review.OfficeId, Review.Rating, 
                Review.Content, Review.CreatedAt, Review.UpdatedAt
                    FROM Review INNER JOIN "AspNetUsers" ON Review.UserId = "AspNetUsers"."Id" 
                        INNER JOIN Office ON Review.OfficeId = P_Id
                            ORDER BY Review.CreatedAt DESC 
                                FETCH NEXT P_Value ROWS ONLY;
    END
$$
LANGUAGE PLPGSQL;
-- 
CREATE OR REPLACE FUNCTION GET_ALL_REVIEW_IN_OFFICE
(
    P_Id CHAR
)
RETURNS TABLE
(
    Id CHAR,
    UserName VARCHAR,
    OfficeId CHAR,
    Rating DECIMAL,
    Content VARCHAR,
    CreatedAt TIMESTAMP,
    UpdatedAt TIMESTAMP
)
AS
$$
    BEGIN
        RETURN QUERY
            SELECT DISTINCT Review.Id, "AspNetUsers"."UserName", Review.OfficeId, Review.Rating, 
                Review.Content, Review.CreatedAt, Review.UpdatedAt
                    FROM Review INNER JOIN "AspNetUsers" ON Review.UserId = "AspNetUsers"."Id" 
                        INNER JOIN Office ON Review.OfficeId = P_Id
                            ORDER BY Review.CreatedAt DESC;
    END
$$
LANGUAGE PLPGSQL;
-- 
CREATE OR REPLACE FUNCTION GET_REVIEW_IN_OFFICE
(
    P_ReviewId CHAR,
    P_OfficeId CHAR
)
RETURNS TABLE
(
    Id CHAR,
    UserName VARCHAR,
    OfficeId CHAR,
    Rating DECIMAL,
    Content VARCHAR,
    CreatedAt TIMESTAMP,
    UpdatedAt TIMESTAMP
)
AS
$$
    BEGIN
        RETURN QUERY
            SELECT DISTINCT Review.Id, "AspNetUsers"."UserName", Review.OfficeId, Review.Rating, 
                Review.Content, Review.CreatedAt, Review.UpdatedAt
                    FROM Review INNER JOIN "AspNetUsers" ON Review.UserId = "AspNetUsers"."Id" 
                        INNER JOIN Office ON Review.OfficeId = P_OfficeId AND Review.Id = P_ReviewId;
    END
$$
LANGUAGE PLPGSQL;
-- Review's PROCEDURE --------------------------------------------------------
CREATE OR REPLACE PROCEDURE CREATE_REVIEW
(
    P_UserId VARCHAR,
    P_OfficeId CHAR,
    P_Rating DECIMAL,
    P_Content VARCHAR
)
AS
$$
    BEGIN
        INSERT INTO Review VALUES
        (
            REVIEW_SEQ.NEXTVAL,
            P_UserId,
            P_OfficeId,
            P_Rating,
            P_Content,
            DEFAULT,
            DEFAULT
        );
    END
$$
LANGUAGE PLPGSQL;
--
CREATE OR REPLACE PROCEDURE UPDATE_REVIEW
(
    P_Id CHAR,
    P_Rating DECIMAL,
    P_Content VARCHAR
)
AS
$$
    BEGIN
        UPDATE Review SET
            Rating = P_Rating,
            Content = P_Content,
            UpdatedAt = DEFAULT
        WHERE Id = P_Id; 
    END
$$
LANGUAGE PLPGSQL;
-- 
CREATE OR REPLACE PROCEDURE DELETE_REVIEW
(
    P_Id CHAR
)
AS
$$
    BEGIN
        DELETE FROM Review WHERE
            Id = P_Id;
    END
$$
LANGUAGE PLPGSQL;


