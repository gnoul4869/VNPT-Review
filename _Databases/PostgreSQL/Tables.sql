SET TRANSACTION READ WRITE;
-- 
START TRANSACTION;
-- Office and Review tables -------------------------------------------------
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
------------------------------------------------------------------------------
COMMIT;