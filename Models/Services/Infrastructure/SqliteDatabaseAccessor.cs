using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using Microsoft.Data.Sqlite;
using People.Models.ViewModels;
using People.Models.Services.Infrastructure;

namespace People.Models.Services.Infrastructure
{
    public class SqliteDatabaseAccessor : IDatabaseAccessor
    {
        public DataSet Query(FormattableString formattableQuery)
        {
            //SqliteCommand prende in input solo string come query,
            //converto formattabelstring in string
            var queryArguments = formattableQuery.GetArguments();
            var sqliteParameters = new List<SqliteParameter>();
            for (var i = 0; i < queryArguments.Length; i++)
            {
                //il costruttore di sqlparam vuole un val numerico in string e valore da
                //iniettare nella query
                var parameter = new SqliteParameter(i.ToString(), queryArguments[i]);
                sqliteParameters.Add(parameter);
                queryArguments[i] = "@" + i;

            }

            string query = formattableQuery.ToString();

            using (var conn = new SqliteConnection("Data Source=Data/People.db"))
            {
                conn.Open();
                using (var cmd = new SqliteCommand(query, conn))
                {
                    cmd.Parameters.AddRange(sqliteParameters);
                    using (var reader = cmd.ExecuteReader())
                    {
                        var dataSet = new DataSet();
                        dataSet.EnforceConstraints = false;
                        do
                        {
                            var dataTable = new DataTable();
                            dataSet.Tables.Add(dataTable);
                            dataTable.Load(reader);
                        } while (!reader.IsClosed);//la proprietà IsClosed mi permette di controlare se tutti i dati sono stati letti o meno da db

                        return dataSet;

                    }
                }
                //conn.Dispose();
            }
        }

        public int QueryInsert(FormattableString formattableQuery)
        {
            var queryArguments = formattableQuery.GetArguments();
            var sqliteParameters = new List<SqliteParameter>();
            for (var i = 0; i < queryArguments.Length; i++)
            {
                //il costruttore di sqlparam vuole un val numerico in string e valore da
                //iniettare nella query
                var parameter = new SqliteParameter(i.ToString(), queryArguments[i]);
                sqliteParameters.Add(parameter);
                queryArguments[i] = "@" + i;
            }

            string query = formattableQuery.ToString();

            using (var conn = new SqliteConnection("Data Source=Data/People.db"))
            {
                conn.Open();

                using (var cmd = new SqliteCommand(query, conn))
                {
                    cmd.Parameters.AddRange(sqliteParameters);

                    cmd.ExecuteNonQuery();
                }

                using (var cmd = new SqliteCommand("SELECT last_insert_rowid();", conn))
                {
                    int lastInsertRowId = Convert.ToInt32(cmd.ExecuteScalar());

                    return lastInsertRowId;
                }
            }
        }

    }
}
