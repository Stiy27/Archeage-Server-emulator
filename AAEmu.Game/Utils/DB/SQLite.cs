﻿using System;
using System.IO;

using AAEmu.Commons.IO;

using Microsoft.Data.Sqlite;

using NLog;

namespace AAEmu.Game.Utils.DB;

public static class SQLite
{
    private static Logger Logger { get; } = LogManager.GetCurrentClassLogger();

    public static SqliteConnection CreateConnection(string directory = "Data", string sqlite = "compact.sqlite3")
    {
        var dbPath = Path.Combine(FileManager.AppPath, directory, sqlite);
        if (!File.Exists(dbPath))
        {
            Logger.Fatal("Server database does not exist: {0} !", dbPath);
            throw new FileNotFoundException("Server database does not exist: " + dbPath);
        }
        var connection = new SqliteConnection($"Data Source=file:{dbPath}; Mode=ReadOnly");
        try
        {
            connection.Open();
        }
        catch (Exception e)
        {
            Logger.Error(e, "Error on SQLite connect: {0}", e.Message);
            throw;
        }

        return connection;
    }
}
