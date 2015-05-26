
Imports System
Imports System.Collections.Generic
Imports System.Web
Imports System.Data.SqlClient
Imports System.Data

Namespace nsDataBasePortal

    '============================================
    '   Data Access Level
    '
    '   Represents the BOTTOM tier of
    '   OO 3-tier software development
    '============================================

    Public Class clsSQLServer

        'data adapter transfers data to and from the database
        Dim DataChannel As SqlDataAdapter = New SqlDataAdapter()

        Dim CommandBuilder As SqlCommandBuilder = New SqlCommandBuilder()

        Dim SQLParams As New ArrayList

        Dim m_QueryResults As New DataTable
        'data row used to store the data for a new record
        Dim m_NewRecord As DataRow
        'string variable used to store the connection string
        Private ConnectionString As String

        Public ReadOnly Property QueryResults As DataTable
            Get
                Return m_QueryResults
            End Get
        End Property

        Public ReadOnly Property NewRecord() As DataRow
            'Provides access to the new record as a single data row
            Get
                Return m_NewRecord
            End Get
        End Property

        Public Sub New(ByVal DBName As String)
            SQLParams.Clear()
            Dim DBPath As String = GetHomeAddr() & "App_Data\" & DBName

            'build up the connection string for the sql server database Visual Studio 2010
            'ConnectionString = "Data Source=.\SQLExpress;Integrated Security=true; AttachDbFilename=" & DBPath & ";User Instance=true;"

            'build up the connection string for the sql server database Visual Studio 2012
            ConnectionString = "Data Source=(LocalDB)\v11.0;AttachDbFilename=" + DBPath + ";Integrated Security=True;Connect Timeout=30"

            'ConnectionString = "Integrated Security=SSPI;Initial Catalog=" & DBPath & ";Data Source=(LocalDB)\\v11.0"

        End Sub

        Private Function GetHomeAddr() As String
            'Folder where Default.aspx is located
            Dim HomeAddr As String = System.AppDomain.CurrentDomain.BaseDirectory
            Return HomeAddr
        End Function

        Public Sub AddParameter(ByVal ParamName As String, ByVal ParamValue As String)
            'public method allowing the addition of an sql parameter to the list of parameters
            'it accepts two parameters the name of the parameter and its value

            'create a new instance of the sql parameter object
            Dim aParam As SqlParameter = New SqlParameter(ParamName, ParamValue)
            'add the parameter to the list
            SQLParams.Add(aParam)
        End Sub

        Public Sub Execute(ByVal SProcName As String)
            'public method used to execute the named stored procedure
            'accepts one parameter which is the name of the stored procedure to use
            'open the stored procedure

            m_QueryResults.Rows.Clear() 'otherwise, the next SELECT appends its records to existing records

            'connection object used to connect to the database
            Dim connectionToDB As SqlConnection

            'initialise the connection to the database
            connectionToDB = New SqlConnection(ConnectionString)
            'open the database
            connectionToDB.Open()
            'initialise the command builder for this connection
            Dim dataCommand As SqlCommand = New SqlCommand(SProcName, connectionToDB)
            'add the parameters to the command builder

            'set the command type as stored procedure
            dataCommand.CommandType = CommandType.StoredProcedure

            If SQLParams.Count > 0 Then
                'loop through each parameter
                For Counter As Integer = 0 To (SQLParams.Count - 1)
                    'add it to the command builder
                    dataCommand.Parameters.Add(SQLParams(Counter))
                Next Counter
            End If

            'initialise the data adapter
            DataChannel = New SqlDataAdapter(SProcName, connectionToDB)
            'set the select command property for the data adapter
            DataChannel.SelectCommand = dataCommand
            'use the copmmand builder to generate the sql insert delete etc
            CommandBuilder = New SqlCommandBuilder(DataChannel)
            'fill the data adapter
            DataChannel.Fill(m_QueryResults)
            'get the structure of a single record
            m_NewRecord = m_QueryResults.NewRow()
            'close the connection
            connectionToDB.Close()
            'clears the parameters
            SQLParams.Clear()
        End Sub

        Public Sub WriteToDatabase()
            'Updates the changes to the data adapter, thus changing the database
            DataChannel.Update(m_QueryResults)
        End Sub

        Public Sub RemoveRecord(ByVal Index As Integer)
            'Removes the record at the specified index position in the query results
            m_QueryResults.Rows(Index).Delete()
        End Sub

        Public Sub AddToDataTable()
            'Adds the new record to the table
            m_QueryResults.Rows.Add(m_NewRecord)
            're initialise the new record
            m_NewRecord = m_QueryResults.NewRow()
        End Sub

        Public Function Count() As Integer
            'Returns the number of records in the query results
            Return m_QueryResults.Rows.Count
        End Function

    End Class

End Namespace
