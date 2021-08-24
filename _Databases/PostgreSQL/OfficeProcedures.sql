SET TRANSACTION READ WRITE;
-- 
START TRANSACTION;
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

        V_Rate := COALESCE(V_Rate / NULLIF(V_Sum,0),0);
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
------------------------------------------------------------------------
COMMIT;