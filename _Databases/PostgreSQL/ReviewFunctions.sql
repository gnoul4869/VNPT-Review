SET TRANSACTION READ WRITE;
-- 
START TRANSACTION;
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
------------------------------------------------------------------------
COMMIT;