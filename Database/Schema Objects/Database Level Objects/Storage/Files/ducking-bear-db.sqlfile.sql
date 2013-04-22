ALTER DATABASE [$(DatabaseName)]
    ADD FILE (NAME = [ducking-bear-db], FILENAME = '$(DefaultDataPath)$(DatabaseName).mdf', FILEGROWTH = 1024 KB) TO FILEGROUP [PRIMARY];

