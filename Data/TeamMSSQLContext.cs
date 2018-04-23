﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms.VisualStyles;
using Models;

namespace Data
{
    public class TeamMSSQLContext : ITeamContext
    {
        /// <summary>
        /// Checks if a team already exists in the database
        /// </summary>
        public bool CheckIfExists(Team team)
        {
            var sqlConnection = DataBase.MsSql;
            try
            {
                sqlConnection.Open();
            }
            catch (Exception e)
            {
                ExceptionSqLiteContext.LogException(e);
                return false;
            }

            var commandText = "Select [Name] From [Team] where [Name] =@name";
            var sqlCommand = new SqlCommand(commandText, sqlConnection);
            sqlCommand.Parameters.Add("name", SqlDbType.NVarChar).Value = team.Name;
            var sqlDataReader = sqlCommand.ExecuteReader();
            if (sqlDataReader.HasRows)
            {
                sqlConnection.Close();
                sqlConnection.Dispose();
                return true;
            }
            sqlConnection.Close();
            sqlConnection.Dispose();
            return false;
        }

        /// <summary>
        /// Adds a team to the database
        /// </summary>
        public bool AddTeam(Team team)
        {
            var sqlConnection = DataBase.MsSql;
            try
            {
                sqlConnection.Open();
            }
            catch (Exception e)
            {
                ExceptionSqLiteContext.LogException(e);
                return false;
            }

            var commandText = "Insert into Team ([Name], [Score], [Turns], [Wins], [Losses]) " +
                              "Values (@name, 0, 0, 0, 0)";
            var sqlCommand = new SqlCommand(commandText, sqlConnection);
            sqlCommand.Parameters.Add("name", SqlDbType.NVarChar).Value = team.Name;
            if (sqlCommand.ExecuteNonQuery() == 1)
            {
                sqlConnection.Close();
                sqlConnection.Dispose();
                return true;
            }
            sqlConnection.Close();
            sqlConnection.Dispose();
            return false;
        }

        /// <summary>
        /// Not used
        /// </summary>
        public Team FillWithData(Team team)
        {
            var sqlConnection = DataBase.MsSql;
            try
            {
                sqlConnection.Open();
            }
            catch (Exception e)
            {
                ExceptionSqLiteContext.LogException(e);
                return team;
            }

            var commandText = "SELECT * From [Team] where [Name] = @name";
            var sqlCommand = new SqlCommand(commandText, sqlConnection);
            sqlCommand.Parameters.Add("name", SqlDbType.NVarChar).Value = team.Name;
            var sqlDataReader = sqlCommand.ExecuteReader();
            while (sqlDataReader.Read())
            {
                if (sqlDataReader.HasRows)
                {
                    var _team = new Team(team.Name, sqlDataReader.GetInt32(2), sqlDataReader.GetInt32(3), sqlDataReader.GetInt32(4), sqlDataReader.GetInt32(5), sqlDataReader.GetDecimal(6), sqlDataReader.GetDecimal(7));
                    sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                    sqlDataReader.Close();
                    sqlDataReader.Dispose();
                    return _team;
                }
            }
            sqlConnection.Close();
            sqlConnection.Dispose();
            sqlDataReader.Close();
            sqlDataReader.Dispose();

            return team;
        }

        /// <summary>
        /// Increase score of given team
        /// </summary>
        public bool IncreaseScore(Team team)
        {
            var sqlConnection = DataBase.MsSql;
            try
            {
                sqlConnection.Open();
            }
            catch (Exception e)
            {
                ExceptionSqLiteContext.LogException(e);
                return false;
            }

            var commandText = "UPDATE [Team] SET [Score] = [Score] + 1 where [Name] = @name";
            var sqlCommand = new SqlCommand(commandText, sqlConnection);
            sqlCommand.Parameters.Add("name", SqlDbType.NVarChar).Value = team.Name;
            if (sqlCommand.ExecuteNonQuery() > 1)
            {
                sqlConnection.Close();
                sqlConnection.Dispose();
                return true;
            }
            sqlConnection.Close();
            sqlConnection.Dispose();

            return false;
        }

        /// <summary>
        /// Decrease score of given team
        /// </summary>
        public bool DecreaseScore(Team team)
        {
            var sqlConnection = DataBase.MsSql;
            try
            {
                sqlConnection.Open();
            }
            catch (Exception e)
            {
                ExceptionSqLiteContext.LogException(e);
                return false;
            }

            var commandText = "UPDATE [Team] SET [Score] = [Score] - 1 where [Name] = @name";
            var sqlCommand = new SqlCommand(commandText, sqlConnection);
            sqlCommand.Parameters.Add("name", SqlDbType.NVarChar).Value = team.Name;
            if (sqlCommand.ExecuteNonQuery() > 1)
            {
                sqlConnection.Close();
                sqlConnection.Dispose();
                return true;
            }
            sqlConnection.Close();
            sqlConnection.Dispose();
            return false;
        }

        /// <summary>
        /// Increase turns of given team
        /// </summary>
        public bool IncreaseTurns(Team team)
        {
            var sqlConnection = DataBase.MsSql;
            try
            {
                sqlConnection.Open();
            }
            catch (Exception e)
            {
                ExceptionSqLiteContext.LogException(e);
                return false;
            }

            var commandText = "UPDATE [Team] SET [Turns] = [Turns] + 1 where [Name] = @name";
            var sqlCommand = new SqlCommand(commandText, sqlConnection);
            sqlCommand.Parameters.Add("name", SqlDbType.NVarChar).Value = team.Name;
            if (sqlCommand.ExecuteNonQuery() > 1)
            {
                sqlConnection.Close();
                sqlConnection.Dispose();
                return true;
            }
            sqlConnection.Close();
            sqlConnection.Dispose();
            return false;
        }

        public bool IncreaseWins(Team team)
        {
            var sqlConnection = DataBase.MsSql;
            try
            {
                sqlConnection.Open();
            }
            catch (Exception e)
            {
                ExceptionSqLiteContext.LogException(e);
                return false;
            }

            var commandText = "UPDATE [Team] SET [Wins] = [Wins] + 1 where [Name] = @name";
            var sqlCommand = new SqlCommand(commandText, sqlConnection);
            sqlCommand.Parameters.Add("name", SqlDbType.NVarChar).Value = team.Name;
            if (sqlCommand.ExecuteNonQuery() > 1)
            {
                sqlConnection.Close();
                sqlConnection.Dispose();
                return true;
            }
            sqlConnection.Close();
            sqlConnection.Dispose();
            return false;
        }

        public bool IncreaseLosses(Team team)
        {
            var sqlConnection = DataBase.MsSql;
            try
            {
                sqlConnection.Open();
            }
            catch (Exception e)
            {
                ExceptionSqLiteContext.LogException(e);
                return false;
            }

            var commandText = "UPDATE [Team] SET [Losses] = [Losses] + 1 where [Name] = @name";
            var sqlCommand = new SqlCommand(commandText, sqlConnection);
            sqlCommand.Parameters.Add("name", SqlDbType.NVarChar).Value = team.Name;
            if (sqlCommand.ExecuteNonQuery() > 1)
            {
                sqlConnection.Close();
                sqlConnection.Dispose();
                return true;
            }
            sqlConnection.Close();
            sqlConnection.Dispose();
            return false;
        }

        /// <summary>
        /// Get all teams sorted by alpabet
        /// </summary>
        public List<Team> GetTeamsByAlphabet()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get all teams sorted by score
        /// </summary>
        public List<Team> GetTeamsByScore()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get all teams sorted by turns
        /// </summary>
        public List<Team> GetTeamByTurns()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get all teams sorted by wins
        /// </summary>
        public List<Team> GetTeamsByWins()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get all teams sorted by winloss
        /// </summary>
        public List<Team> GetTeamsByWinLoss()
        {
            throw new NotImplementedException();
        }
    }
}
