SET TRANSACTION READ WRITE;
-- 
START TRANSACTION;
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
            NEXTVAL('REVIEW_SEQ'),
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
------------------------------------------------------------------------
COMMIT;