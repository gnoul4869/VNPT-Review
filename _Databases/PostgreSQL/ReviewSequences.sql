SET TRANSACTION READ WRITE;
-- 
START TRANSACTION;
-- Review's SEQUENCES -------------------------------------------------------
CREATE SEQUENCE REVIEW_SEQ
    MINVALUE 1
    START WITH 1
    INCREMENT BY 1
    OWNED BY Review.Id;
------------------------------------------------------------------------
COMMIT;

