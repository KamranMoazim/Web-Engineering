
-- Create a new table called 'Profile' in schema 'dbo'
-- Drop the table if it already exists
IF OBJECT_ID('MyDB.dbo.TweetProfile', 'U') IS NOT NULL
DROP TABLE MyDB.dbo.TweetProfile;
GO
-- Create the table in the specified schema
CREATE TABLE MyDB.dbo.TweetProfile
(
    ProfileId INT IDENTITY(1,1) PRIMARY KEY, -- primary key column
    Firstname [NVARCHAR](50) NOT NULL,
    Lastname [NVARCHAR](50) NOT NULL,
    TagLine [NVARCHAR](100) NOT NULL,
    Birthdate [DATETIME] NOT NULL,
    JoinedDate [DATETIME] NOT NULL DEFAULT GETDATE(),

    UserId INT NOT NULL,
    -- specify more columns here
    FOREIGN KEY (UserId)
    REFERENCES MyDB.dbo.TweetUser (UserId)
    ON DELETE CASCADE
);
GO


-- Create a new table called 'TweetFollow' in schema 'dbo'
-- Drop the table if it already exists
IF OBJECT_ID('MyDB.dbo.TweetFollow', 'U') IS NOT NULL
DROP TABLE MyDB.dbo.TweetFollow;
GO
-- Create the table in the specified schema
CREATE TABLE MyDB.dbo.TweetFollow
(
    TweetFollowId INT IDENTITY(1,1) PRIMARY KEY, -- primary key column
    
    UserId INT NOT NULL,
    FollowedUserId INT NOT NULL,
    -- specify more columns here

    FOREIGN KEY (UserId)
    REFERENCES MyDB.dbo.TweetUser (UserId)
    ON DELETE CASCADE,

    FOREIGN KEY (FollowedUserId)
    REFERENCES MyDB.dbo.TweetUser (UserId)

);
GO


-- Create a new table called 'Tweet' in schema 'dbo'
-- Drop the table if it already exists
IF OBJECT_ID('MyDB.dbo.ReTweet', 'U') IS NOT NULL
DROP TABLE MyDB.dbo.ReTweet
GO
-- Create the table in the specified schema
CREATE TABLE MyDB.dbo.ReTweet
(
    ReTweetId INT IDENTITY(1,1) PRIMARY KEY, -- primary key column
    SharedDate [DATETIME] NOT NULL,
    TweetId INT NOT NULL,
    UserId INT NOT NULL,
    -- specify more columns here

    FOREIGN KEY (TweetId)
    REFERENCES MyDB.dbo.Tweet (TweetId)
    ON DELETE CASCADE,

    FOREIGN KEY (UserId)
    REFERENCES MyDB.dbo.TweetUser (UserId)
    
);
GO  


-- Create a new table called 'TweetTags' in schema 'dbo'
-- Drop the table if it already exists
IF OBJECT_ID('MyDB.dbo.TweetTag', 'U') IS NOT NULL
DROP TABLE MyDB.dbo.TweetTag
GO
-- Create the table in the specified schema
CREATE TABLE MyDB.dbo.TweetTag
(
    TagId INT IDENTITY(1,1) PRIMARY KEY, -- primary key column
    Tag [NVARCHAR](10) NOT NULL,
    TweetId INT NOT NULL,
    -- specify more columns here
    FOREIGN KEY (TweetId)
    REFERENCES MyDB.dbo.Tweet (TweetId)
    ON DELETE CASCADE
);
GO


-- Create a new table called 'Comment' in schema 'dbo'
-- Drop the table if it already exists
IF OBJECT_ID('MyDB.dbo.TweetComment', 'U') IS NOT NULL
DROP TABLE MyDB.dbo.TweetComment
GO
-- Create the table in the specified schema
CREATE TABLE MyDB.dbo.TweetComment
(
    CommentId INT IDENTITY(1,1) PRIMARY KEY, -- primary key column
    Comment [NVARCHAR](50) NOT NULL,
    PostedDate [DATETIME] NOT NULL,
    UserId INT NOT NULL,
    TweetId INT NOT NULL,
    -- specify more columns here
    FOREIGN KEY (UserId)
    REFERENCES MyDB.dbo.TweetUser (UserId)
    ON DELETE CASCADE,

    FOREIGN KEY (TweetId)
    REFERENCES MyDB.dbo.Tweet (TweetId)
    
);
GO




-- Create a new table called 'Comment' in schema 'dbo'
-- Drop the table if it already exists
IF OBJECT_ID('MyDB.dbo.TweetLike', 'U') IS NOT NULL
DROP TABLE MyDB.dbo.TweetLike
GO
-- Create the table in the specified schema
CREATE TABLE MyDB.dbo.TweetLike
(
    TweetLikeId INT IDENTITY(1,1) PRIMARY KEY, -- primary key column
    UserId INT NOT NULL,
    TweetId INT NOT NULL,
    -- specify more columns here
    FOREIGN KEY (UserId)
    REFERENCES MyDB.dbo.TweetUser (UserId)
    ON DELETE CASCADE,

    FOREIGN KEY (TweetId)
    REFERENCES MyDB.dbo.Tweet (TweetId)

);
GO



-- Create a new table called 'Tweet' in schema 'dbo'
-- Drop the table if it already exists
IF OBJECT_ID('MyDB.dbo.Tweet', 'U') IS NOT NULL
DROP TABLE MyDB.dbo.Tweet
GO
-- Create the table in the specified schema
CREATE TABLE MyDB.dbo.Tweet
(
    TweetId INT IDENTITY(1,1) PRIMARY KEY, -- primary key column
    Title [NVARCHAR](50) NOT NULL,
    Content [NVARCHAR](500) NOT NULL,
    PostedDate [DATETIME] NOT NULL,
    LikeCount INT NOT NULL DEFAULT 0,
    RetweetCount INT NOT NULL DEFAULT 0,
    UserId INT NOT NULL,
    -- specify more columns here
    FOREIGN KEY (UserId)
    REFERENCES MyDB.dbo.TweetUser (UserId)
    
);
GO



-- Create a new table called 'User' in schema 'dbo'
-- Drop the table if it already exists
IF OBJECT_ID('MyDB.dbo.TweetUser', 'U') IS NOT NULL
DROP TABLE MyDB.dbo.TweetUser;
GO
-- Create the table in the specified schema
CREATE TABLE MyDB.dbo.TweetUser
(
    UserId INT IDENTITY(1,1) PRIMARY KEY, -- primary key column
    Username [NVARCHAR](50) NOT NULL,
    Password [NVARCHAR](8) NOT NULL
    -- specify more columns here
);
GO

