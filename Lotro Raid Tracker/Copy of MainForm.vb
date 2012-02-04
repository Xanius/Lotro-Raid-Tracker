Imports System.Data.SQLite

Public Class MainForm
	Dim CurrentCharacter As String = vbNullString
	Structure Raid
		Dim RaidName As String
		Dim DayCompleted As DateTime
		Dim CharacterName As String
	End Structure
	Structure Character
		Dim Name As String
		Dim Server As String
	End Structure

	Private Sub Form1_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        FlowLayoutPanel1.Controls.Clear()
		Dim CharacterArray As New ArrayList
		Dim Characters As Character
		ComboBox1.Items.Clear()
		RaidPicker.Items.Clear()
		Dim SQLconnect As New SQLite.SQLiteConnection()
		Dim SQLcommand As SQLiteCommand
		'SQLconnect.ConnectionString = "Data Source=" & f.FileName & ";"
		SQLconnect.ConnectionString = "Data Source=.\Database\LotroRaids.sqlite;"
		Try
			SQLconnect.Open()
		Catch ex As Exception

		End Try
		SQLcommand = SQLconnect.CreateCommand
		SQLcommand.CommandText = "Select * from Characters"
		Dim SQLReaderCharacter As SQLiteDataReader = SQLcommand.ExecuteReader()
		While SQLReaderCharacter.Read()
			Characters = New Character
			With Characters
				.Name = SQLReaderCharacter("CharacterName")
				.Server = SQLReaderCharacter("Server")
			End With
			CharacterArray.Add(Characters)
		End While
		SQLReaderCharacter.Close()
		For Each item In CharacterArray
			Dim newitem As String
			newitem = item.name + " - " + item.server
			ComboBox1.Items.Add(newitem)
		Next
		If ComboBox1.Items.Count > 0 Then
			ComboBox1.SelectedIndex = 0
		End If
		SQLcommand.CommandText = "Select Translation from Dictionary WHERE IsRaid='True'"
		Dim SQLReaderRaids As SQLiteDataReader = SQLcommand.ExecuteReader()
        While SQLReaderRaids.Read()
            Dim raid As New Label
            raid.Name = SQLReaderRaids("Translation")
            raid.Text = SQLReaderRaids("Translation")
            raid.ForeColor = Color.Lime
            raid.AutoSize = True
            RaidPicker.Items.Add(SQLReaderRaids("Translation"))
            FlowLayoutPanel1.Controls.Add(raid)
        End While
		SQLconnect.Close()
		SQLconnect.Dispose()
        'LoadStatus()


	End Sub
#Region "Interface Actions"
	
	Private Sub ComboBox1_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
		CurrentCharacter = ComboBox1.SelectedItem.ToString.Split("-")(0).Trim


        'LoadStatus()
	End Sub

#End Region
#Region "Menu"
	Private Sub ExitToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ExitToolStripMenuItem.Click
		Me.Close()
	End Sub
	Private Sub AddRaidToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles AddRaidToolStripMenuItem.Click
		'Add Code to add a new raid to database.
	End Sub
	Private Sub AddCharacterToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles AddCharacterMenu.Click, cmdAddCharacter.Click
		Dim ServerInput
		Dim NameInput = InputBox("Enter your characters name.", "Character Name")
		If NameInput IsNot "" Then
			ServerInput = InputBox("Enter your characters server.", "Server Name")
		Else
			Return
		End If
		Dim SQLconnect As New SQLite.SQLiteConnection()
		Dim SQLcommand As SQLiteCommand
		SQLconnect.ConnectionString = "Data Source=.\Database\LotroRaids.sqlite;"
		SQLconnect.Open()
		SQLcommand = SQLconnect.CreateCommand

		SQLcommand.CommandText = "INSERT INTO Characters ('CharacterName','Server') VALUES('" + NameInput + "','" + ServerInput + "')"
		SQLcommand.ExecuteNonQuery()

		SQLcommand.CommandText = "INSERT INTO Raids ('DayComplete','RaidName','CharacterName','Server') VALUES ('1/1/1990','LabelGondamon','" + NameInput + "','" + ServerInput + "')"
		SQLcommand.ExecuteNonQuery()
		SQLcommand.CommandText = "INSERT INTO Raids ('DayComplete','RaidName','CharacterName','Server') VALUES ('1/1/1990','LabelTuckborough','" + NameInput + "','" + ServerInput + "')"
		SQLcommand.ExecuteNonQuery()
		SQLcommand.CommandText = "INSERT INTO Raids ('DayComplete','RaidName','CharacterName','Server') VALUES ('1/1/1990','LabelAmonSul','" + NameInput + "','" + ServerInput + "')"
		SQLcommand.ExecuteNonQuery()
		SQLcommand.CommandText = "INSERT INTO Raids ('DayComplete','RaidName','CharacterName','Server') VALUES ('1/1/1990','LabelAttackAtDawn','" + NameInput + "','" + ServerInput + "')"
		SQLcommand.ExecuteNonQuery()
		SQLcommand.CommandText = "INSERT INTO Raids ('DayComplete','RaidName','CharacterName','Server') VALUES ('1/1/1990','LabelThievery','" + NameInput + "','" + ServerInput + "')"
		SQLcommand.ExecuteNonQuery()
		SQLcommand.CommandText = "INSERT INTO Raids ('DayComplete','RaidName','CharacterName','Server') VALUES ('1/1/1990','LabelPony','" + NameInput + "','" + ServerInput + "')"
		SQLcommand.ExecuteNonQuery()
		SQLcommand.CommandText = "INSERT INTO Raids ('DayComplete','RaidName','CharacterName','Server') VALUES ('1/1/1990','LabelBruinen','" + NameInput + "','" + ServerInput + "')"
		SQLcommand.ExecuteNonQuery()
		SQLcommand.CommandText = "INSERT INTO Raids ('DayComplete','RaidName','CharacterName','Server') VALUES ('1/1/1990','LabelIcy','" + NameInput + "','" + ServerInput + "')"
		SQLcommand.ExecuteNonQuery()
		SQLcommand.CommandText = "INSERT INTO Raids ('DayComplete','RaidName','CharacterName','Server') VALUES ('1/1/1990','LabelBarrows','" + NameInput + "','" + ServerInput + "')"
		SQLcommand.ExecuteNonQuery()
		SQLcommand.CommandText = "INSERT INTO Raids ('DayComplete','RaidName','CharacterName','Server') VALUES ('1/1/1990','LabelDeepWay','" + NameInput + "','" + ServerInput + "')"
		SQLcommand.ExecuteNonQuery()
		SQLcommand.CommandText = "INSERT INTO Raids ('DayComplete','RaidName','CharacterName','Server') VALUES ('1/1/1990','LabelSmiths','" + NameInput + "','" + ServerInput + "')"
		SQLcommand.ExecuteNonQuery()
		SQLcommand.CommandText = "INSERT INTO Raids ('DayComplete','RaidName','CharacterName','Server') VALUES ('1/1/1990','Label21st','" + NameInput + "','" + ServerInput + "')"
		SQLcommand.ExecuteNonQuery()
		SQLcommand.CommandText = "INSERT INTO Raids ('DayComplete','RaidName','CharacterName','Server') VALUES ('1/1/1990','LabelDannenglor','" + NameInput + "','" + ServerInput + "')"
		SQLcommand.ExecuteNonQuery()
		SQLcommand.CommandText = "INSERT INTO Raids ('DayComplete','RaidName','CharacterName','Server') VALUES ('1/1/1990','LabelThangulhad','" + NameInput + "','" + ServerInput + "')"
		SQLcommand.ExecuteNonQuery()
		SQLcommand.CommandText = "INSERT INTO Raids ('DayComplete','RaidName','CharacterName','Server') VALUES ('1/1/1990','LabelNecromancer','" + NameInput + "','" + ServerInput + "')"
		SQLcommand.ExecuteNonQuery()
		SQLcommand.CommandText = "INSERT INTO Raids ('DayComplete','RaidName','CharacterName','Server') VALUES ('1/1/1990','LabelRingwraith','" + NameInput + "','" + ServerInput + "')"
		SQLcommand.ExecuteNonQuery()
		SQLcommand.CommandText = "INSERT INTO Raids ('DayComplete','RaidName','CharacterName','Server') VALUES ('1/1/1990','LabelTowerBattle','" + NameInput + "','" + ServerInput + "')"
		SQLcommand.ExecuteNonQuery()
		SQLcommand.CommandText = "INSERT INTO Raids ('DayComplete','RaidName','CharacterName','Server') VALUES ('1/1/1990','LabelRescue','" + NameInput + "','" + ServerInput + "')"
		SQLcommand.ExecuteNonQuery()
		SQLcommand.CommandText = "INSERT INTO Raids ('DayComplete','RaidName','CharacterName','Server') VALUES ('1/1/1990','LabelDraigoch','" + NameInput + "','" + ServerInput + "')"
		SQLcommand.ExecuteNonQuery()
		SQLcommand.CommandText = "INSERT INTO Raids ('DayComplete','RaidName','CharacterName','Server') VALUES ('1/1/1990','LabelSpiderWing','" + NameInput + "','" + ServerInput + "')"
		SQLcommand.ExecuteNonQuery()
		SQLcommand.CommandText = "INSERT INTO Raids ('DayComplete','RaidName','CharacterName','Server') VALUES ('1/1/1990','LabelGiantWing','" + NameInput + "','" + ServerInput + "')"
		SQLcommand.ExecuteNonQuery()
		SQLcommand.CommandText = "INSERT INTO Raids ('DayComplete','RaidName','CharacterName','Server') VALUES ('1/1/1990','LabelDrakeWing','" + NameInput + "','" + ServerInput + "')"
		SQLcommand.ExecuteNonQuery()
		SQLcommand.CommandText = "INSERT INTO Raids ('DayComplete','RaidName','CharacterName','Server') VALUES ('1/1/1990','LabelDragonWing','" + NameInput + "','" + ServerInput + "')"
		SQLcommand.ExecuteNonQuery()
		SQLcommand.CommandText = "INSERT INTO Raids ('DayComplete','RaidName','CharacterName','Server') VALUES ('1/1/1990','LabelThievery','" + NameInput + "','" + ServerInput + "')"
		SQLcommand.ExecuteNonQuery()
		SQLcommand.Dispose()
		SQLconnect.Close()
		SQLconnect.Dispose()
		Me.Form1_Load(Me, e)
	End Sub
	Private Sub DeleteCharacterMenu_Click(sender As System.Object, e As System.EventArgs) Handles DeleteCharacterMenu.Click, cmdDeleteCharacter.Click
		Dim SQLconnect As New SQLite.SQLiteConnection()
		Dim SQLcommand As SQLiteCommand
		SQLconnect.ConnectionString = "Data Source=.\Database\LotroRaids.sqlite;"
		SQLconnect.Open()
		SQLcommand = SQLconnect.CreateCommand
		Try
			SQLcommand.CommandText = "Delete FROM Raids WHERE CharacterName = '" + ComboBox1.SelectedItem.ToString.Split("-")(0).Trim + "' AND Server='" + ComboBox1.SelectedItem.ToString.Split("-")(1).Trim + "'"
			SQLcommand.ExecuteNonQuery()
			SQLcommand.CommandText = "Delete FROM Characters WHERE CharacterName = '" + ComboBox1.SelectedItem.ToString.Split("-")(0).Trim + "' AND Server='" + ComboBox1.SelectedItem.ToString.Split("-")(1).Trim + "'"
			SQLcommand.ExecuteNonQuery()
		Catch ex As Exception
			MessageBox.Show("Please select a character in the drop down list first.", "No Character Selected", MessageBoxButtons.OK, MessageBoxIcon.Error)
		End Try
		ComboBox1.Items.Remove(ComboBox1.SelectedItem)
		Try
			If ComboBox1.Items.Count > 0 Then
				ComboBox1.SelectedIndex = 0
			Else
				ComboBox1.Text = ""
			End If
		Catch ex As Exception

		End Try
		SQLcommand.Dispose()
		SQLconnect.Close()
		SQLconnect.Dispose()

		Me.Form1_Load(Me, e)
	End Sub
	Private Sub ResetCharacterMenu_Click(sender As System.Object, e As System.EventArgs) Handles menuResetCharacter.Click, cmdReset.Click
		Dim SQLconnect As New SQLite.SQLiteConnection()
		Dim SQLcommand As SQLiteCommand
		SQLconnect.ConnectionString = "Data Source=.\Database\LotroRaids.sqlite;"
		SQLconnect.Open()
		SQLcommand = SQLconnect.CreateCommand
		Try
			SQLcommand.CommandText = "UPDATE Raids SET DayComplete ='" + Date.Today + "' WHERE CharacterName = '" + ComboBox1.SelectedItem.ToString.Split("-")(0).Trim + "' AND Server ='" + ComboBox1.SelectedItem.ToString.Split("-")(1).Trim + "'"
			SQLcommand.ExecuteNonQuery()
		Catch ex As Exception
			MessageBox.Show("Please select a character in the drop down list first.", "No Character Selected", MessageBoxButtons.OK, MessageBoxIcon.Error)
		End Try
		SQLcommand.Dispose()
		SQLconnect.Close()

		Me.Form1_Load(Me, e)
	End Sub
	Private Sub HelpToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles SupportToolStripMenuItem.Click
		System.Diagnostics.Process.Start("http://forums.lotro.com/showthread.php?427002-Releasing-Lotro-Raid-Tracker-1.0")
	End Sub
	Private Sub AboutToolStripMenuItem1_Click(sender As System.Object, e As System.EventArgs) Handles AboutToolStripMenuItem.Click
		AboutBox1.Show()
	End Sub
#End Region
#Region "Status Changes"
	Private Sub SetComplete(ByVal LabelName As Label)


		Dim SQLconnect As New SQLite.SQLiteConnection()
		Dim SQLcommand As SQLiteCommand
		SQLconnect.ConnectionString = "Data Source=.\Database\LotroRaids.sqlite;"

		SQLcommand = SQLconnect.CreateCommand
        Dim mThursday As DateTime = NextThursday()
        mThursday.AddHours(7)

		Try
			SQLcommand.CommandText = "UPDATE Raids SET DayComplete = '" + mThursday + "' WHERE RaidName = '" + LabelName.Name + "' AND CharacterName = '" + ComboBox1.SelectedItem.ToString.Split("-")(0).Trim + "' AND Server='" + ComboBox1.SelectedItem.ToString.Split("-")(1).Trim + "'"
			SQLconnect.Open()
			SQLcommand.ExecuteNonQuery()
			SQLcommand.Dispose()
			SQLconnect.Close()
			LabelName.ForeColor = Color.Red
		Catch ex As Exception
			If ComboBox1.SelectedItem.ToString.Split("-")(0).Trim = "" Then
				MessageBox.Show("Please create a character under File -> Add character first.", "No Characters Found!", MessageBoxButtons.OK, MessageBoxIcon.Error)
			Else
				MessageBox.Show(ex.ToString, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
			End If
			SQLconnect.Close()
			SQLconnect.Dispose()
		End Try


		SQLconnect.Dispose()
	End Sub
	Private Sub SetInComplete(ByVal LabelName As Label)
		Dim SQLconnect As New SQLite.SQLiteConnection()
		Dim SQLcommand As SQLiteCommand
		'SQLconnect.ConnectionString = "Data Source=" & f.FileName & ";"
		SQLconnect.ConnectionString = "Data Source=.\Database\LotroRaids.sqlite;"
		SQLconnect.Open()
		SQLcommand = SQLconnect.CreateCommand
		'Insert Record into Foo
		'Update Last Created Record in Foo
		Try
			SQLcommand.CommandText = "UPDATE Raids SET DayComplete = '" + Date.Today() + "' WHERE RaidName = '" + LabelName.Name + "' AND CharacterName = '" + ComboBox1.SelectedItem.ToString.Split("-")(0).Trim + "' AND Server='" + ComboBox1.SelectedItem.ToString.Split("-")(1).Trim + "'"
			'Uncomment this to be able to insert Name fields in to the datbase.
			'SQLcommand.CommandText = "INSERT INTO Raids ('Name','CharacterName') VALUES('" + LabelName.Name + "','" + ComboBox1.SelectedItem.ToString.Split("-")(0).Trim + "'"
			SQLcommand.ExecuteNonQuery()
			SQLcommand.Dispose()
			LabelName.ForeColor = Color.Lime
		Catch ex As Exception
			MessageBox.Show("Please create a character under File -> Add character first.", "No Characters Found!", MessageBoxButtons.OK, MessageBoxIcon.Error)
			SQLconnect.Close()
			SQLconnect.Dispose()
			SQLconnect.Shutdown()
		End Try

		SQLconnect.Close()
		SQLconnect.Dispose()
		SQLconnect.Shutdown()
	End Sub
	
    'Private Sub LoadStatus()
    '	Dim Raid(30) As Raid
    '	If CurrentCharacter IsNot vbNullString Then
    '		Dim SQLconnect As New SQLite.SQLiteConnection()
    '		Dim SQLcommand As SQLiteCommand
    '		SQLconnect.ConnectionString = "Data Source=.\Database\LotroRaids.sqlite;"
    '		Try
    '			SQLconnect.Open()
    '		Catch ex As Exception

    '		End Try
    '		SQLcommand = SQLconnect.CreateCommand
    '		Try
    '			SQLcommand.CommandText = "Select * from Raids WHERE CharacterName ='" + ComboBox1.SelectedItem.ToString.Split("-")(0).Trim + "' AND Server ='" + ComboBox1.SelectedItem.ToString.Split("-")(1).Trim + "'"


    '			Dim SQLreaderRaids As SQLiteDataReader = SQLcommand.ExecuteReader()

    '			Dim i = 0
    '			While SQLreaderRaids.Read()
    '				Raid(i).DayCompleted = SQLreaderRaids("DayComplete")
    '				Raid(i).RaidName = SQLreaderRaids("RaidName")

    '                   If Date.Now.ToUniversalTime < Raid(i).DayCompleted Then
    '                       Select Case Raid(i).RaidName
    '                           Case "Label21st"
    '                               Label21st.ForeColor = Color.Red

    '                           Case "LabelAmonSul"
    '                               LabelAmonSul.ForeColor = Color.Red

    '                           Case "LabelAttackAtDawn"
    '                               LabelAttackAtDawn.ForeColor = Color.Red

    '                           Case "LabelBarrows"
    '                               LabelBarrows.ForeColor = Color.Red

    '                           Case "LabelBruinen"
    '                               LabelBruinen.ForeColor = Color.Red

    '                           Case "LabelDannenglor"
    '                               LabelDannenglor.ForeColor = Color.Red

    '                           Case "LabelDeepWay"
    '                               LabelDeepWay.ForeColor = Color.Red

    '                           Case "LabelDraigoch"
    '                               LabelDraigoch.ForeColor = Color.Red

    '                           Case "LabelGondamon"
    '                               LabelGondamon.ForeColor = Color.Red

    '                           Case "LabelIcy"
    '                               LabelIcy.ForeColor = Color.Red

    '                           Case "LabelNecromancer"
    '                               LabelNecromancer.ForeColor = Color.Red

    '                           Case "LabelPony"
    '                               LabelPony.ForeColor = Color.Red

    '                           Case "LabelRescue"
    '                               LabelRescue.ForeColor = Color.Red

    '                           Case "LabelRingwraith"
    '                               LabelRingwraith.ForeColor = Color.Red

    '                           Case "LabelSmiths"
    '                               LabelSmiths.ForeColor = Color.Red

    '                           Case "LabelThangulhad"
    '                               LabelThangulhad.ForeColor = Color.Red

    '                           Case "LabelThievery"
    '                               LabelThievery.ForeColor = Color.Red

    '                           Case "LabelTowerBattle"
    '                               LabelTowerBattle.ForeColor = Color.Red

    '                           Case "LabelTuckborough"
    '                               LabelTuckborough.ForeColor = Color.Red

    '                           Case "LabelSpiderWing"
    '                               LabelSpiderWing.ForeColor = Color.Red

    '                           Case "LabelGiantWing"
    '                               LabelGiantWing.ForeColor = Color.Red

    '                           Case "LabelDrakeWing"
    '                               LabelDrakeWing.ForeColor = Color.Red

    '                           Case "LabelDragonWing"
    '                               LabelDragonWing.ForeColor = Color.Red

    '                       End Select
    '                   End If

    '				i += 1
    '			End While
    '		Catch ex As Exception

    '		End Try
    '		SQLcommand.Dispose()
    '		SQLconnect.Close()
    '	End If

    'End Sub
#End Region
	Private Function NextThursday() As DateTime
        Dim dt As DateTime = DateTime.Today
        Dim datediff As TimeSpan
        datediff = DateAndTime.Now.Date - Date.FromOADate(0).Date
        dt = Date.FromOADate(datediff.Days + 0.291666666)
        If dt.DayOfWeek = DayOfWeek.Thursday Then

            dt = dt.AddDays(7)

        Else
            While dt.DayOfWeek <> DayOfWeek.Thursday

                dt = dt.AddDays(1)
            End While
        End If
		
		Return dt
	End Function

    'Private Sub cmdComplete_Click(sender As System.Object, e As System.EventArgs) Handles cmdComplete.Click, CmdNotComplete.Click
    '	Dim RaidName As String
    '	'	Dim RaidLabel As Label
    '       Dim SQLOutput As String = ""
    '	Dim SQLconnect As New SQLite.SQLiteConnection()
    '	Dim SQLcommand As SQLiteCommand
    '	'SQLconnect.ConnectionString = "Data Source=" & f.FileName & ";"
    '	SQLconnect.ConnectionString = "Data Source=.\Database\LotroRaids.sqlite;"
    '	SQLconnect.Open()
    '	SQLcommand = SQLconnect.CreateCommand
    '	'Insert Record into Foo
    '	'Update Last Created Record in Foo
    '       Try
    '           If RaidPicker.SelectedItem.ToString.Contains("'") Then
    '               RaidName = RaidPicker.SelectedItem.ToString.Replace("'", "''")
    '           Else
    '               RaidName = RaidPicker.SelectedItem.ToString
    '           End If
    '       Catch
    '           MessageBox.Show("Please select an item from the drop down menu first.")
    '           Return
    '       End Try

    '       SQLcommand.CommandText = "Select Dictionary.UIObject from Dictionary WHERE Translation='" + RaidName + "'"

    '       Dim UIObjectReader As SQLiteDataReader = SQLcommand.ExecuteReader()
    '       While UIObjectReader.Read()
    '           SQLOutput = UIObjectReader("UIObject")
    '       End While
    '       SQLcommand.Dispose()
    '       SQLconnect.Close()

    '       Select Case SQLOutput
    '           Case "Label21st"
    '               If sender.Name = "cmdComplete" Then
    '                   SetComplete(Label21st)
    '               Else
    '                   SetInComplete(Label21st)
    '               End If
    '           Case "LabelAmonSul"
    '               If sender.Name = "cmdComplete" Then
    '                   SetComplete(LabelAmonSul)
    '               Else
    '                   SetInComplete(LabelAmonSul)
    '               End If
    '           Case "LabelAttackAtDawn"
    '               If sender.Name = "cmdComplete" Then
    '                   SetComplete(LabelAttackAtDawn)
    '               Else
    '                   SetInComplete(LabelAttackAtDawn)
    '               End If
    '           Case "LabelBarrows"
    '               If sender.Name = "cmdComplete" Then
    '                   SetComplete(LabelBarrows)
    '               Else
    '                   SetInComplete(LabelBarrows)
    '               End If
    '           Case "LabelBruinen"
    '               If sender.Name = "cmdComplete" Then
    '                   SetComplete(LabelBruinen)
    '               Else
    '                   SetInComplete(LabelBruinen)
    '               End If
    '           Case "LabelDannenglor"
    '               If sender.Name = "cmdComplete" Then
    '                   SetComplete(LabelDannenglor)
    '               Else
    '                   SetInComplete(LabelDannenglor)
    '               End If
    '           Case "LabelDeepWay"
    '               If sender.Name = "cmdComplete" Then
    '                   SetComplete(LabelDeepWay)
    '               Else
    '                   SetInComplete(LabelDeepWay)
    '               End If
    '           Case "LabelDraigoch"
    '               If sender.Name = "cmdComplete" Then
    '                   SetComplete(LabelDraigoch)
    '               Else
    '                   SetInComplete(LabelDraigoch)
    '               End If
    '           Case "LabelGondamon"
    '               If sender.Name = "cmdComplete" Then
    '                   SetComplete(LabelGondamon)
    '               Else
    '                   SetInComplete(LabelGondamon)
    '               End If
    '           Case "LabelIcy"
    '               If sender.Name = "cmdComplete" Then
    '                   SetComplete(LabelIcy)
    '               Else
    '                   SetInComplete(LabelIcy)
    '               End If
    '           Case "LabelNecromancer"
    '               If sender.Name = "cmdComplete" Then
    '                   SetComplete(LabelNecromancer)
    '               Else
    '                   SetInComplete(LabelNecromancer)
    '               End If
    '           Case "LabelPony"
    '               If sender.Name = "cmdComplete" Then
    '                   SetComplete(LabelPony)
    '               Else
    '                   SetInComplete(LabelPony)
    '               End If
    '           Case "LabelRescue"
    '               If sender.Name = "cmdComplete" Then
    '                   SetComplete(LabelRescue)
    '               Else
    '                   SetInComplete(LabelRescue)
    '               End If
    '           Case "LabelRingwraith"
    '               If sender.Name = "cmdComplete" Then
    '                   SetComplete(LabelRingwraith)
    '               Else
    '                   SetInComplete(LabelRingwraith)
    '               End If
    '           Case "LabelSmiths"
    '               If sender.Name = "cmdComplete" Then
    '                   SetComplete(LabelSmiths)
    '               Else
    '                   SetInComplete(LabelSmiths)
    '               End If
    '           Case "LabelThangulhad"
    '               If sender.Name = "cmdComplete" Then
    '                   SetComplete(LabelThangulhad)
    '               Else
    '                   SetInComplete(LabelThangulhad)
    '               End If
    '           Case "LabelThievery"
    '               If sender.Name = "cmdComplete" Then
    '                   SetComplete(LabelThievery)
    '               Else
    '                   SetInComplete(LabelThievery)
    '               End If
    '           Case "LabelTowerBattle"
    '               If sender.Name = "cmdComplete" Then
    '                   SetComplete(LabelTowerBattle)
    '               Else
    '                   SetInComplete(LabelTowerBattle)
    '               End If
    '           Case "LabelTuckborough"
    '               If sender.Name = "cmdComplete" Then
    '                   SetComplete(LabelTuckborough)
    '               Else
    '                   SetInComplete(LabelTuckborough)

    '               End If
    '           Case "LabelSpiderWing"
    '               If sender.Name = "cmdComplete" Then
    '                   SetComplete(LabelSpiderWing)
    '               Else
    '                   SetInComplete(LabelSpiderWing)

    '               End If
    '           Case "LabelGiantWing"
    '               If sender.Name = "cmdComplete" Then
    '                   SetComplete(LabelGiantWing)
    '               Else
    '                   SetInComplete(LabelGiantWing)

    '               End If
    '           Case "LabelDrakeWing"
    '               If sender.Name = "cmdComplete" Then
    '                   SetComplete(LabelDrakeWing)
    '               Else
    '                   SetInComplete(LabelDrakeWing)

    '               End If
    '           Case "LabelDragonWing"
    '               If sender.Name = "cmdComplete" Then
    '                   SetComplete(LabelDragonWing)
    '               Else
    '                   SetInComplete(LabelDragonWing)

    '               End If

    '       End Select
    '       'SQLcommand.CommandText = "UPDATE Raids SET Raids.DayComplete = '" + NextThursday() + "' WHERE Raids.RaidName ='" + RaidLabel.Name + "' AND CharacterName = '" + ComboBox1.SelectedItem.ToString.Split("-")(0).Trim + "' AND Sever ='" + ComboBox1.SelectedItem.ToString.Split("-")(1).Trim + "'"
    '       'Uncomment this to be able to insert Name fields in to the datbase.
    '       'SQLcommand.CommandText = "INSERT INTO Raids ('Name','CharacterName') VALUES('" + LabelName.Name + "','" + ComboBox1.SelectedItem.ToString.Split("-")(0).Trim + "'"
    '       '	SQLcommand.ExecuteNonQuery()
    '       '	SQLcommand.Dispose()
    '       '	RaidLabel.ForeColor = Color.Red
    '       'Catch ex As Exception
    '       '	MessageBox.Show("Please create a character under File -> Add character first.", "No Characters Found!", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '       'End Try


    '   End Sub

	Private Sub cmdCompleteAll_Click(sender As System.Object, e As System.EventArgs) Handles cmdCompleteAll.Click, menuCompleteAll.Click
		Dim SQLconnect As New SQLite.SQLiteConnection()
		Dim SQLcommand As SQLiteCommand
		'SQLconnect.ConnectionString = "Data Source=" & f.FileName & ";"
		SQLconnect.ConnectionString = "Data Source=.\Database\LotroRaids.sqlite;"
		SQLconnect.Open()
		SQLcommand = SQLconnect.CreateCommand
		SQLcommand.CommandText = "UPDATE Raids SET DayComplete = '" + NextThursday() + "' WHERE CharacterName = '" + ComboBox1.SelectedItem.ToString.Split("-")(0).Trim + "' AND Server ='" + ComboBox1.SelectedItem.ToString.Split("-")(1).Trim + "'"
		SQLcommand.ExecuteNonQuery()
		SQLcommand.Dispose()
		SQLConnect.close()
		SQLconnect.dispose()
        'LoadStatus()

	End Sub
End Class
