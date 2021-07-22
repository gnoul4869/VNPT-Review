CREATE TABLE Office (
    Id CHARACTER(5),
    Name VARCHAR2(50),
    Note VARCHAR2(200),
    FatherId CHARACTER(5),
    Active NUMBER(1),
    Rating DECIMAL DEFAULT 0,
    CreatedAt DATE DEFAULT CURRENT_TIMESTAMP,
    UpdatedAt DATE DEFAULT CURRENT_TIMESTAMP,
    -- 
    PRIMARY KEY (Id)
);
-- 
CREATE TABLE Review (
    Id CHARACTER(64),
    OfficeId CHARACTER(5),
    Rating DECIMAL,
    Content VARCHAR2(200),
    CreatedAt DATE DEFAULT CURRENT_TIMESTAMP,
    UpdatedAt DATE DEFAULT CURRENT_TIMESTAMP,
    --
    PRIMARY KEY (Id),
    CONSTRAINT FK_ID
        FOREIGN KEY (OfficeId) REFERENCES Office (Id) ON DELETE CASCADE
);
-- SEQUENCES ----------------------------------------------------------------
CREATE SEQUENCE REVIEW_SEQ 
    MINVALUE 1
    START WITH 1
    INCREMENT BY 1
    NOCACHE;
-- Office's PROCEDURES ------------------------------------------------------
CREATE OR REPLACE PROCEDURE UPDATE_OFFICE_RATING
(
    P_Id IN CHARACTER
)
AS
    V_Rate DECIMAL DEFAULT 0;
    V_Sum DECIMAL DEFAULT 0;
BEGIN
    FOR X IN (SELECT Rating FROM Review Where Review.OfficeId = P_Id)
    LOOP
        V_Rate := V_Rate + X.Rating;
        V_Sum := V_Sum + 1;
        dbms_output.put_line(X.Rating);
    END LOOP;

    V_Rate := NVL(V_Rate / NULLIF(V_Sum,0),0);
    UPDATE Office SET Office.Rating = V_Rate WHERE Office.Id = P_Id;
END;
-- 
CREATE OR REPLACE PROCEDURE GET_PAGINATED_OFFICE
(
    P_SearchValue IN VARCHAR2 DEFAULT NULL,
    P_ValueNo IN INT DEFAULT 0,
    P_PageSize IN INT DEFAULT 10,
    P_SortColumn IN INT DEFAULT 0,
    P_SortDirection IN VARCHAR2 DEFAULT 'ASC'
)
AS
    C1 SYS_REFCURSOR;
    V_TotalCount INT;
    V_FirstRecord INT;
    V_LastRecord INT;
    V_SearchValue VARCHAR2(255);
BEGIN
    SELECT COUNT(*) INTO V_TotalCount FROM Office;

    V_FirstRecord := P_ValueNo + 1;
    V_LastRecord := P_ValueNo + P_PageSize;
    V_SearchValue := LTRIM(RTRIM(P_SearchValue));

    OPEN C1 FOR
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
        WHERE NVL(V_SearchValue, '') = ''
        OR UPPER(Office.Name) LIKE UPPER('%' || V_SearchValue || '%')
        )
        SELECT 
            RowNumber,
            FilteredCount,
            TotalCount,
            Id,
            Name,
            Note,
            FatherId,
            Active,
            Rating
        FROM CTE_RESULTS WHERE RowNumber BETWEEN V_FirstRecord AND V_LastRecord;
    DBMS_SQL.RETURN_RESULT(C1);
END;
-- 
CREATE OR REPLACE PROCEDURE GET_OFFICE_COUNT
AS
    C1 SYS_REFCURSOR;
BEGIN
    OPEN C1 FOR
        SELECT COUNT(*) FROM Office;
    DBMS_SQL.RETURN_RESULT(C1);
END;
-- 
CREATE OR REPLACE PROCEDURE GET_ALL_OFFICE
AS
    C1 SYS_REFCURSOR;
BEGIN
    OPEN C1 FOR
        SELECT
            Office.Id,
            Office.Name,
            Office.Note,
            Office.FatherId,
            Office.Active,
            Office.Rating
        FROM Office ORDER BY Office.Id;
    DBMS_SQL.RETURN_RESULT(C1);
END;
-- 
CREATE OR REPLACE PROCEDURE GET_OFFICE
(
    P_Id IN CHARACTER
)
AS
    C1 SYS_REFCURSOR;
BEGIN
    OPEN C1 FOR 
        SELECT 
            Office.Id,
            Office.Name,
            Office.Note,
            Office.FatherId,
            Office.Active,
            Office.Rating
        FROM Office WHERE Office.Id = P_Id;
    DBMS_SQL.RETURN_RESULT(C1);
END;
-- 
CREATE OR REPLACE PROCEDURE CREATE_OFFICE
(
    P_Id IN CHARACTER,
    P_Name IN VARCHAR2,
    P_Note IN VARCHAR2,
    P_FatherId IN CHARACTER,
    P_Active IN NUMBER
)
AS
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
END;
-- 
CREATE OR REPLACE PROCEDURE UPDATE_OFFICE
(
    P_Id IN CHARACTER,
    P_Name IN VARCHAR2,
    P_Note IN VARCHAR2,
    P_FatherId IN CHARACTER,
    P_Active IN NUMBER
)
AS
BEGIN
    UPDATE Office SET
        Office.Name = P_Name,
        Office.Note = P_Note,
        Office.FatherId = P_FatherId,
        Office.Active = P_Active,
        Office.UpdatedAt = DEFAULT
    WHERE Office.Id = P_Id; 
END;
-- 
CREATE OR REPLACE PROCEDURE DELETE_OFFICE
(
    P_Id IN CHARACTER
)
AS
BEGIN
    DELETE FROM Office WHERE
        Office.Id = P_Id;
END;
-- Review's PROCEDURE ------------------------------------------------------
CREATE OR REPLACE PROCEDURE GET_ALL_REVIEW_IN_OFFICE
(
    P_Id IN CHARACTER
)
AS
    C1 SYS_REFCURSOR;
BEGIN
    OPEN C1 FOR 
        SELECT DISTINCT Review.Id, Review.OfficeId, Review.Rating, 
            Review.Content, Review.CreatedAt, Review.UpdatedAt
                FROM Review INNER JOIN Office ON Office.Id = P_Id;
    DBMS_SQL.RETURN_RESULT(C1);
END;
-- 
CREATE OR REPLACE PROCEDURE GET_REVIEW_IN_OFFICE
(
    P_ReviewId IN CHARACTER,
    P_OfficeId IN CHARACTER
)
AS
    C1 SYS_REFCURSOR;
BEGIN
    OPEN C1 FOR
        SELECT DISTINCT Review.Id, Review.OfficeId, Review.Rating, 
            Review.Content, Review.CreatedAt, Review.UpdatedAt
                FROM Review INNER JOIN Office ON Review.OfficeId = P_OfficeId AND Review.Id = P_ReviewId;
    DBMS_SQL.RETURN_RESULT(C1);
END;
-- 
CREATE OR REPLACE PROCEDURE CREATE_REVIEW
(
    P_OfficeId IN CHARACTER,
    P_Rating IN DECIMAL,
    P_Content IN VARCHAR2
)
AS
BEGIN
    INSERT INTO Review VALUES
    (
        REVIEW_SEQ.NEXTVAL,
        P_OfficeId,
        P_Rating,
        P_Content,
        DEFAULT,
        DEFAULT
    );
END;
-- 
CREATE OR REPLACE PROCEDURE UPDATE_REVIEW
(
    P_Id IN CHARACTER,
    P_Rating IN DECIMAL,
    P_Content IN VARCHAR2
)
AS
BEGIN
    UPDATE Review SET
        Review.Rating = P_Rating,
        Review.Content = P_Content,
        Review.UpdatedAt = DEFAULT
    WHERE Review.Id = P_Id; 
END;
-- 
CREATE OR REPLACE PROCEDURE DELETE_REVIEW
(
    P_Id IN CHARACTER
)
AS
BEGIN
    DELETE FROM Review WHERE
        Review.Id = P_Id;
END;


