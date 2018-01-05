
#Region " Imports "
Imports System.Data.OleDb
Imports System.Text
Imports Base
#End Region

Public Class Fairr
    Implements IP2pProcessor

#Region " Porperties "
    Private Property ImportDT As DataTable Implements IP2pProcessor.ImportDT
#End Region

#Region " Declarations "
    Private FilePath As String
    Private WknDIC As New Dictionary(Of String, String)
#End Region

#Region " Contructor "
    Public Sub New(FilePath As String)
        Me.FilePath = FilePath
        BuildWknDIC()
        ReadFile()
    End Sub
#End Region

#Region " Private Sub BuildWknDIC () "
    Private Sub BuildWknDIC()
        WknDIC.Add("Kauf db x-tr. Portf.Total Ret. UCITS ETF", "DBX0BT")
        WknDIC.Add("Kauf Comstage Stoxx Europe 600 Nr UCITS", "ETF060")
        WknDIC.Add("Kauf Deka MDAX UCITS ETF", "ETFL44")
        WknDIC.Add("Kauf Dimensional Gl.Short Fixed Income F", "A0YAPN")
        WknDIC.Add("Kauf Dimensional Emerg.Markets Value F.", "A0YAPZ")
        WknDIC.Add("Kauf Dimensional Europ.Small Companies F", "A1JH97")
        WknDIC.Add("Kauf Dimensional European Value Fund", "A0YAN6")
        WknDIC.Add("Kauf Dimensional Global Targeted Value F", "A0RMKW")
        WknDIC.Add("Kauf Dimensional Global Core Equity Fund", "A0RMKV")
        WknDIC.Add("Kauf Dimensional World Equity Fund EUR", "A1JUY0")

        WknDIC.Add("Kauf DBXT.PTF TOT.RET.U.ETF 1C", "DBX0BT")
        WknDIC.Add("Kauf CS.-STX.EU.600 NR U.ETF I", "ETF060")
        WknDIC.Add("Kauf DEKA MDAX", "ETFL44")
        WknDIC.Add("Kauf DIM.FDS-WORLD EQ.EOACC", "A1JUY0")
        WknDIC.Add("Kauf D.FDS-GL SHT FIX.I.EOA", "A0YAPN")
        WknDIC.Add("Kauf DIMENSIONAL-E.MKTS VA.EOA", "A0YAPZ")
        WknDIC.Add("Kauf DIM.FDS-EUROP.S.COS EUR D", "A1JH97")
        WknDIC.Add("Kauf D.FDS-EURO.VALUE EUR ACC.", "A0YAN6")
        WknDIC.Add("Kauf D.FDS-GL.TAR.VAL.EUR ACC.", "A0RMKW")
        WknDIC.Add("Kauf DIM.FDS-GL.CO.EQ.EUR ACC", "A0RMKV")

        WknDIC.Add("Saldenausgleich DBXT.PTF TOT.RET.U.ETF 1C", "DBX0BT")
        WknDIC.Add("Saldenausgleich DEKA MDAX", "ETFL44")
        WknDIC.Add("Saldenausgleich D.FDS-GL.TAR.VAL.EUR ACC.", "A0RMKW")
        WknDIC.Add("Saldenausgleich DIM.FDS-WORLD EQ.EOACC", "A1JUY0")
        WknDIC.Add("Saldenausgleich D.FDS-GL SHT FIX.I.EOA", "A0YAPN")
        WknDIC.Add("Saldenausgleich DIMENSIONAL-E.MKTS VA.EOA", "A0YAPZ")
        WknDIC.Add("Saldenausgleich DIM.FDS-EUROP.S.COS EUR D", "A1JH97")
        WknDIC.Add("Saldenausgleich D.FDS-EURO.VALUE EUR ACC.", "A0YAN6")
        WknDIC.Add("Saldenausgleich DIM.FDS-GL.CO.EQ.EUR ACC", "A0RMKV")
        WknDIC.Add("Saldenausgleich CS.-STX.EU.600 NR U.ETF I", "ETF060")



    End Sub
#End Region

#Region " Private Sub ReadFile "
    Private Sub ReadFile() Implements IP2pProcessor.ReadFile
        Me.ImportDT = Fkt.ReadXlsToDatatable(Me.FilePath, "Umsätze$")
    End Sub
#End Region

#Region " Public Sub Process "
    Public Sub Process() Implements IP2pProcessor.Process
        '>>> Exit if datatalbe is nothing
        If Me.ImportDT Is Nothing Then Exit Sub
        '>>> Start conversion
        Dim requestDateLimitation As New DateSelectWindow
        If requestDateLimitation.ShowDialog = DialogResult.OK Then
            '>>> Remove first 6 rows
            For i = 1 To 6
                Me.ImportDT.Rows.Remove(Me.ImportDT.Rows(0))
            Next
            Dim csvOutputFileName As String = System.IO.Path.GetDirectoryName(Me.FilePath) & "\Fairr-export.csv"
            Dim csvOutputFile As IO.StreamWriter = My.Computer.FileSystem.OpenTextFileWriter(csvOutputFileName, False, Encoding.GetEncoding(1252))
            csvOutputFile.WriteLine("Datum;Wert;WKN;Buchungswährung;Stück")
            For Each row As DataRow In Me.ImportDT.Rows
                If Me.WknDIC.Keys.Contains(row(3).ToString) Then
                    If CDate(row(1)) > requestDateLimitation.DateTimePicker.Value Then
                        csvOutputFile.WriteLine(row(1).ToString & ";" &
                                                                    row(2).ToString & ";" &
                                                                    Me.WknDIC(row(3).ToString) & ";" &
                                                                    row(6).ToString & ";" &
                                                                    row(7).ToString)
                    End If
                End If
            Next
            csvOutputFile.Close()
            MsgBox("File successfully exported")
        End If
    End Sub
#End Region

End Class
