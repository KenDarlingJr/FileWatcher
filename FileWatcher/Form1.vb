Imports System.Media

Public Class Form1

    Dim WatchPath As String
    Dim WatchFile As String
    'Color.Chartreuse

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtWatchPath.Text = My.Settings.WatchPath
        txtWatchFile.Text = My.Settings.WatchFile

    End Sub

    Private Sub btnStart_Click(sender As Object, e As EventArgs) Handles btnStart.Click

        My.Settings.WatchPath = txtWatchPath.Text
        My.Settings.WatchFile = txtWatchFile.Text

        WatchFile = My.Settings.WatchFile

        FileSystemWatcher1.Path = My.Settings.WatchPath
        'Wildcards will work on filtere
        '   *.*             All files (default). An empty string ("") also watches all files.
        '   *.txt           All files with a "txt" extension.
        '   MyReport.Doc    Watches only MyReport.doc
        '   *recipe.doc     All files ending in "recipe" with a "doc" extension.
        '   win*.xml        All files beginning with "win" with an "xml" extension.
        '   Sales*200?.xls  Matches the following: Sales July 2001.xls, Sales Aug 2002.xls, Sales March 2004.xls
        '                   but does not match: Sales Nov 1999.xls

        FileSystemWatcher1.Filter = WatchFile

        ' add event handlers
        AddHandler FileSystemWatcher1.Changed, AddressOf OnChanged
        AddHandler FileSystemWatcher1.Created, AddressOf OnCreated
        AddHandler FileSystemWatcher1.Deleted, AddressOf OnDeleted

        ListView1.Items.Add("File Watcher Started!")


    End Sub

    Private Sub OnChanged(sender As Object, e As IO.FileSystemEventArgs)

        Dim listViewItem = New ListViewItem
        listViewItem.Text = ("File Changed : " & e.Name & " " & DateAndTime.Now)

        listViewItem.ForeColor = Color.Yellow
        ListView1.Items.Add(listViewItem)
        ListView1.EnsureVisible(ListView1.Items.Count - 1)
        ListView1.Update()

    End Sub

    Private Sub OnCreated(sender As Object, e As IO.FileSystemEventArgs)

        Dim listViewItem = New ListViewItem
        listViewItem.Text = ("File Created : " & e.Name & " " & DateAndTime.Now)

        listViewItem.ForeColor = Color.DeepSkyBlue
        ListView1.Items.Add(listViewItem)
        ListView1.EnsureVisible(ListView1.Items.Count - 1)
        ListView1.Update()

    End Sub

    Private Sub OnDeleted(sender As Object, e As IO.FileSystemEventArgs)

        Dim listViewItem = New ListViewItem
        listViewItem.Text = "File Deleted : " & e.Name & " " & DateAndTime.Now

        listViewItem.Font = New Font(ListView1.Font, FontStyle.Italic)
        listViewItem.ForeColor = Color.Red
        ListView1.Items.Add(listViewItem)
        ListView1.EnsureVisible(ListView1.Items.Count - 1)
        ListView1.Update()
        SystemSounds.Beep.Play()

    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        ListView1.Items.Clear()
    End Sub
End Class
