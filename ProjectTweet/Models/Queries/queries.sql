-- SELECT TOP 50 * FROM MyDB.dbo.Tweet t
--     JOIN MyDB.dbo.Comment c ON t.TweetId = c.TweetId


-- SELECT * FROM MyDB.dbo.Comment 
--     INNER JOIN MyDB.dbo.TweetUser 
--     ON Comment.UserId = TweetUser.UserId WHERE Comment.TweetId = TweetId

-- SELECT TOP 5 * FROM MyDB.dbo.Tweet ORDER BY (SELECT COUNT(*) FROM MyDB.dbo.Comment WHERE MyDB.dbo.Comment.TweetId = MyDB.dbo.Tweet.TweetId) DESC

-- SELECT * FROM MyDB.dbo.Tweet t ORDER BY t.TweetId


SELECT * FROM MyDB.dbo.Comment INNER JOIN MyDB.dbo.TweetUser ON MyDB.dbo.Comment.UserId = MyDB.dbo.TweetUser.UserId  WHERE MyDB.dbo.Comment.TweetId = 1