﻿using System.Data.SqlClient;
using System.Windows.Forms;
using System;

public class DBManipulator
{
    private readonly static string connectionString = "Server=localhost;Database=ISDA;Integrated Security=true;";
    private SqlConnection connection; private SqlCommand command;
    public DBManipulator()
    {
        try
        {
            this.connection = new SqlConnection(connectionString);
            this.command = new SqlCommand(); this.command.Connection = this.connection;
        }
        catch (Exception e) { MessageBox.Show(e.ToString()); }
    }
    public SqlConnection GetConnection() { return this.connection; }
    public SqlCommand GetCommand()
    {
        this.command.Parameters.Clear(); return this.command;
    }
}