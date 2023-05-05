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
    UserId INT NOT NULL,
    -- specify more columns here
    CONSTRAINT fk_user_id_to_tweet
    FOREIGN KEY (UserId)
    REFERENCES MyDB.dbo.TweetUser (UserId)
    ON DELETE CASCADE
);
GO


-- Create a new table called 'TweetTags' in schema 'dbo'
-- Drop the table if it already exists
IF OBJECT_ID('MyDB.dbo.TweetTags', 'U') IS NOT NULL
DROP TABLE MyDB.dbo.TweetTags
GO
-- Create the table in the specified schema
CREATE TABLE MyDB.dbo.TweetTags
(
    TagId INT IDENTITY(1,1) PRIMARY KEY, -- primary key column
    Tag [NVARCHAR](10) NOT NULL,
    TweetId INT NOT NULL,
    -- specify more columns here
    CONSTRAINT fk_tag_id_to_tweet
    FOREIGN KEY (TweetId)
    REFERENCES MyDB.dbo.Tweet (TweetId)
    ON DELETE CASCADE
);
GO


-- Create a new table called 'Comment' in schema 'dbo'
-- Drop the table if it already exists
IF OBJECT_ID('MyDB.dbo.Comment', 'U') IS NOT NULL
DROP TABLE MyDB.dbo.Comment
GO
-- Create the table in the specified schema
CREATE TABLE MyDB.dbo.Comment
(
    CommentId INT IDENTITY(1,1) PRIMARY KEY, -- primary key column
    Comment [NVARCHAR](50) NOT NULL,
    PostedDate [DATETIME] NOT NULL,
    UserId INT NOT NULL,
    TweetId INT NOT NULL,
    -- specify more columns here
    CONSTRAINT fk_comment_id_to_user
    FOREIGN KEY (UserId)
    REFERENCES MyDB.dbo.TweetUser (UserId)
    ON DELETE CASCADE,

    CONSTRAINT fk_comment_id_to_tweet
    FOREIGN KEY (TweetId)
    REFERENCES MyDB.dbo.Tweet (TweetId)
);
GO
