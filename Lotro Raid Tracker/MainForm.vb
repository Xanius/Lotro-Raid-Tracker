Imports System.Data.SQLite

Public Class MainForm
	Dim CurrentCharacter As String = vbNullString
	Structure Raid
		Dim Name As String
		Dim DayCompleted As DateTime
		Dim CharacterName As String
	End Structure
	Structure Character
		Dim Name As String
		Dim Server As String
	End Structure

	Private Sub Form1_Load(sender As Object, e As System.EventArgs) Handles Me.Load

		Dim CharacterArray As New ArrayList
		Dim Characters As Character
		ComboBox1.Items.Clear()

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
		For Each item In CharacterArray
			Dim newitem As String
			newitem = item.name + " - " + item.server
			ComboBox1.Items.Add(newitem)
		Next
		If ComboBox1.Items.Count > 0 Then
			ComboBox1.SelectedIndex = 0
		End If

		LoadStatus()

		SQLconnect.Close()
	End Sub
#Region "Interface Actions"
	Private Sub Button_Click(sender As System.Object, e As System.EventArgs) Handles ButtonGondamon.Click, Button21st.Click, ButtonAmonSul.Click, ButtonAttackAtDawn.Click, ButtonBarrows.Click, ButtonBruinen.Click, ButtonDannenglor.Click, ButtonDeepWay.Click, ButtonIcy.Click, ButtonNecromancer.Click, ButtonPony.Click, ButtonRescue.Click, ButtonRingwraith.Click, ButtonSmiths.Click, ButtonThangulhad.Click, ButtonThievery.Click, ButtonTowerBattle.Click, ButtonTuckborough.Click, ButtonDraigoch.Click
		Select Case sender.name
			Case "Button21st"
				If sender.text = "Completed" Then
					SetComplete(Label21st, Button21st)
					sender.text = "Not Completed"
				Else
					SetIncomplete(Label21st, Button21st)
					sender.text = "Completed"
				End If

			Case "ButtonAmonSul"
				If sender.text = "Completed" Then
					SetComplete(LabelAmonSul, ButtonAmonSul)
					sender.text = "Not Completed"
				Else
					SetInComplete(LabelAmonSul, ButtonAmonSul)
					sender.text = "Completed"
				End If
			Case "ButtonAttackAtDawn"
				If sender.text = "Completed" Then
					SetComplete(LabelAttackAtDawn, ButtonAttackAtDawn)
					sender.text = "Not Completed"
				Else
					SetInComplete(LabelAttackAtDawn, ButtonAttackAtDawn)
					sender.text = "Completed"
				End If
			Case "ButtonBarrows"
				If sender.text = "Completed" Then
					SetComplete(LabelBarrows, ButtonBarrows)
					sender.text = "Not Completed"
				Else
					SetInComplete(LabelBarrows, ButtonBarrows)
					sender.text = "Completed"
				End If
			Case "ButtonBruinen"
				If sender.text = "Completed" Then
					SetComplete(LabelBruinen, ButtonBruinen)
					sender.text = "Not Completed"
				Else
					SetInComplete(LabelBruinen, ButtonBruinen)
					sender.text = "Completed"
				End If
			Case "ButtonDannenglor"
				If sender.text = "Completed" Then
					SetComplete(LabelDannenglor, ButtonDannenglor)
					sender.text = "Not Completed"
				Else
					SetInComplete(LabelDannenglor, ButtonDannenglor)
					sender.text = "Completed"
				End If
			Case "ButtonDeepWay"
				If sender.text = "Completed" Then
					SetComplete(LabelDeepWay, ButtonDeepWay)
					sender.text = "Not Completed"
				Else
					SetInComplete(LabelDeepWay, ButtonDeepWay)
					sender.text = "Completed"
				End If
			Case "ButtonDraigoch"
				If sender.text = "Completed" Then
					SetComplete(LabelDraigoch, ButtonDraigoch)
					sender.text = "Not Completed"
				Else
					SetInComplete(LabelDraigoch, ButtonDraigoch)
					sender.text = "Completed"
				End If
			Case "ButtonGondamon"
				If sender.text = "Completed" Then
					SetComplete(LabelGondamon, ButtonGondamon)
					sender.text = "Not Completed"
				Else
					SetInComplete(LabelGondamon, ButtonGondamon)
					sender.text = "Completed"
				End If
			Case "ButtonIcy"
				If sender.text = "Completed" Then
					SetComplete(LabelIcy, ButtonIcy)
					sender.text = "Not Completed"
				Else
					SetInComplete(LabelIcy, ButtonIcy)
					sender.text = "Completed"
				End If
			Case "ButtonNecromancer"
				If sender.text = "Completed" Then
					SetComplete(LabelNecromancer, ButtonNecromancer)
					sender.text = "Not Completed"
				Else
					SetInComplete(LabelNecromancer, ButtonNecromancer)
					sender.text = "Completed"
				End If
			Case "ButtonPony"
				If sender.text = "Completed" Then
					SetComplete(LabelPony, ButtonPony)
					sender.text = "Not Completed"
				Else
					SetInComplete(LabelPony, ButtonPony)
					sender.text = "Completed"
				End If
			Case "ButtonRescue"
				If sender.text = "Completed" Then
					SetComplete(LabelRescue, ButtonRescue)
					sender.text = "Not Completed"
				Else
					SetInComplete(LabelRescue, ButtonRescue)
					sender.text = "Completed"
				End If
			Case "ButtonRingwraith"
				If sender.text = "Completed" Then
					SetComplete(LabelRingwraith, ButtonRingwraith)
					sender.text = "Not Completed"
				Else
					SetInComplete(LabelRingwraith, ButtonRingwraith)
					sender.text = "Completed"
				End If
			Case "ButtonSmiths"
				If sender.text = "Completed" Then
					SetComplete(LabelSmiths, ButtonSmiths)
					sender.text = "Not Completed"
				Else
					SetInComplete(LabelSmiths, ButtonSmiths)
					sender.text = "Completed"
				End If
			Case "ButtonThangulhad"
				If sender.text = "Completed" Then
					SetComplete(LabelThangulhad, ButtonThangulhad)
					sender.text = "Not Completed"
				Else
					SetInComplete(LabelThangulhad, ButtonThangulhad)
					sender.text = "Completed"
				End If
			Case "ButtonThievery"
				If sender.text = "Completed" Then
					SetComplete(LabelThievery, ButtonThievery)
					sender.text = "Not Completed"
				Else
					SetInComplete(LabelThievery, ButtonThievery)
					sender.text = "Completed"
				End If
			Case "ButtonTowerBattle"
				If sender.text = "Completed" Then
					SetComplete(LabelTowerBattle, ButtonTowerBattle)
					sender.text = "Not Completed"
				Else
					SetInComplete(LabelTowerBattle, ButtonTowerBattle)
					sender.text = "Completed"
				End If
			Case "ButtonTuckborough"
				If sender.text = "Completed" Then
					SetComplete(LabelTuckborough, ButtonTuckborough)
					sender.text = "Not Completed"
				Else
					SetInComplete(LabelTuckborough, ButtonTuckborough)
					sender.text = "Completed"
				End If
		End Select
	End Sub
	Private Sub ComboBox1_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
		CurrentCharacter = ComboBox1.SelectedItem.ToString.Split("-")(0).Trim
		ColorReset()

		LoadStatus()
	End Sub
	
#End Region
#Region "Menu"
	Private Sub ExitToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ExitToolStripMenuItem.Click
		Me.Close()
	End Sub
	Private Sub AddRaidToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles AddRaidToolStripMenuItem.Click
		'Add Code to add a new raid to database.
	End Sub
	Private Sub AddCharacterToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles AddCharacterMenu.Click
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

		SQLcommand.CommandText = "INSERT INTO Raids ('DayComplete','Name','CharacterName') VALUES ('1/1/1990','LabelGondamon','" + NameInput + "')"
		SQLcommand.ExecuteNonQuery()
		SQLcommand.CommandText = "INSERT INTO Raids ('DayComplete','Name','CharacterName') VALUES ('1/1/1990','LabelTuckborough','" + NameInput + "')"
		SQLcommand.ExecuteNonQuery()
		SQLcommand.CommandText = "INSERT INTO Raids ('DayComplete','Name','CharacterName') VALUES ('1/1/1990','LabelAmonSul','" + NameInput + "')"
		SQLcommand.ExecuteNonQuery()
		SQLcommand.CommandText = "INSERT INTO Raids ('DayComplete','Name','CharacterName') VALUES ('1/1/1990','LabelAttackAtDawn','" + NameInput + "')"
		SQLcommand.ExecuteNonQuery()
		SQLcommand.CommandText = "INSERT INTO Raids ('DayComplete','Name','CharacterName') VALUES ('1/1/1990','LabelThievery','" + NameInput + "')"
		SQLcommand.ExecuteNonQuery()
		SQLcommand.CommandText = "INSERT INTO Raids ('DayComplete','Name','CharacterName') VALUES ('1/1/1990','LabelPony','" + NameInput + "')"
		SQLcommand.ExecuteNonQuery()
		SQLcommand.CommandText = "INSERT INTO Raids ('DayComplete','Name','CharacterName') VALUES ('1/1/1990','LabelBruinen','" + NameInput + "')"
		SQLcommand.ExecuteNonQuery()
		SQLcommand.CommandText = "INSERT INTO Raids ('DayComplete','Name','CharacterName') VALUES ('1/1/1990','LabelIcy','" + NameInput + "')"
		SQLcommand.ExecuteNonQuery()
		SQLcommand.CommandText = "INSERT INTO Raids ('DayComplete','Name','CharacterName') VALUES ('1/1/1990','LabelBarrows','" + NameInput + "')"
		SQLcommand.ExecuteNonQuery()
		SQLcommand.CommandText = "INSERT INTO Raids ('DayComplete','Name','CharacterName') VALUES ('1/1/1990','LabelDeepWay','" + NameInput + "')"
		SQLcommand.ExecuteNonQuery()
		SQLcommand.CommandText = "INSERT INTO Raids ('DayComplete','Name','CharacterName') VALUES ('1/1/1990','LabelSmiths','" + NameInput + "')"
		SQLcommand.ExecuteNonQuery()
		SQLcommand.CommandText = "INSERT INTO Raids ('DayComplete','Name','CharacterName') VALUES ('1/1/1990','Label21st','" + NameInput + "')"
		SQLcommand.ExecuteNonQuery()
		SQLcommand.CommandText = "INSERT INTO Raids ('DayComplete','Name','CharacterName') VALUES ('1/1/1990','LabelDannenglor','" + NameInput + "')"
		SQLcommand.ExecuteNonQuery()
		SQLcommand.CommandText = "INSERT INTO Raids ('DayComplete','Name','CharacterName') VALUES ('1/1/1990','LabelThangulhad','" + NameInput + "')"
		SQLcommand.ExecuteNonQuery()
		SQLcommand.CommandText = "INSERT INTO Raids ('DayComplete','Name','CharacterName') VALUES ('1/1/1990','LabelNecromancer','" + NameInput + "')"
		SQLcommand.ExecuteNonQuery()
		SQLcommand.CommandText = "INSERT INTO Raids ('DayComplete','Name','CharacterName') VALUES ('1/1/1990','LabelRingwraith','" + NameInput + "')"
		SQLcommand.ExecuteNonQuery()
		SQLcommand.CommandText = "INSERT INTO Raids ('DayComplete','Name','CharacterName') VALUES ('1/1/1990','LabelTowerBattle','" + NameInput + "')"
		SQLcommand.ExecuteNonQuery()
		SQLcommand.CommandText = "INSERT INTO Raids ('DayComplete','Name','CharacterName') VALUES ('1/1/1990','LabelRescue','" + NameInput + "')"
		SQLcommand.ExecuteNonQuery()
		SQLcommand.CommandText = "INSERT INTO Raids ('DayComplete','Name','CharacterName') VALUES ('1/1/1990','LabelDraigoch','" + NameInput + "')"
		SQLcommand.ExecuteNonQuery()
		SQLcommand.Dispose()
		SQLconnect.Close()
		Me.Form1_Load(Me, e)
	End Sub
	Private Sub DeleteCharacterMenu_Click(sender As System.Object, e As System.EventArgs) Handles DeleteCharacterMenu.Click
		Dim SQLconnect As New SQLite.SQLiteConnection()
		Dim SQLcommand As SQLiteCommand
		SQLconnect.ConnectionString = "Data Source=.\Database\LotroRaids.sqlite;"
		SQLconnect.Open()
		SQLcommand = SQLconnect.CreateCommand
		Try
			SQLcommand.CommandText = "Delete FROM Raids WHERE CharacterName = '" + ComboBox1.SelectedItem.ToString.Split("-")(0).Trim + "'"
			SQLcommand.ExecuteNonQuery()
			SQLcommand.CommandText = "Delete FROM Characters WHERE CharacterName = '" + ComboBox1.SelectedItem.ToString.Split("-")(0).Trim + "'"
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
		
		Me.Form1_Load(Me, e)
	End Sub
	Private Sub ResetCharacterMenu_Click(sender As System.Object, e As System.EventArgs) Handles ResetCharacterMenu.Click
		Dim SQLconnect As New SQLite.SQLiteConnection()
		Dim SQLcommand As SQLiteCommand
		SQLconnect.ConnectionString = "Data Source=.\Database\LotroRaids.sqlite;"
		SQLconnect.Open()
		SQLcommand = SQLconnect.CreateCommand
		Try
			SQLcommand.CommandText = "UPDATE Raids SET DayComplete ='" + Date.Today + "' WHERE CharacterName = '" + ComboBox1.SelectedItem.ToString.Split("-")(0).Trim + "'"
			SQLcommand.ExecuteNonQuery()
		Catch ex As Exception
			MessageBox.Show("Please select a character in the drop down list first.", "No Character Selected", MessageBoxButtons.OK, MessageBoxIcon.Error)
		End Try
		ColorReset()
		Me.Form1_Load(Me, e)
	End Sub
	Private Sub HelpToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles HelpToolStripMenuItem.Click
		System.Diagnostics.Process.Start("http://forums.lotro.com/showthread.php?427002-Releasing-Lotro-Raid-Tracker-1.0")
	End Sub
	Private Sub AboutToolStripMenuItem1_Click(sender As System.Object, e As System.EventArgs) Handles AboutToolStripMenuItem1.Click
		AboutBox1.Show()
	End Sub
#End Region
#Region "Status Changes"
	Private Sub SetComplete(ByVal LabelName As Label, ByVal ButtonName As Button)


		Dim SQLconnect As New SQLite.SQLiteConnection()
		Dim SQLcommand As SQLiteCommand
		'SQLconnect.ConnectionString = "Data Source=" & f.FileName & ";"
		SQLconnect.ConnectionString = "Data Source=.\Database\LotroRaids.sqlite;"
		SQLconnect.Open()
		SQLcommand = SQLconnect.CreateCommand
		'Insert Record into Foo
		'Update Last Created Record in Foo
		Try
			SQLcommand.CommandText = "UPDATE Raids SET DayComplete = '" + NextThursday() + "' WHERE Name = '" + LabelName.Name + "' AND CharacterName = '" + ComboBox1.SelectedItem.ToString.Split("-")(0).Trim + "'"
			'Uncomment this to be able to insert Name fields in to the datbase.
			'SQLcommand.CommandText = "INSERT INTO Raids ('Name','CharacterName') VALUES('" + LabelName.Name + "','" + ComboBox1.SelectedItem.ToString.Split("-")(0).Trim + "'"
			SQLcommand.ExecuteNonQuery()
			SQLcommand.Dispose()
			LabelName.ForeColor = Color.Red
		Catch ex As Exception
			MessageBox.Show("Please create a character under File -> Add character first.", "No Characters Found!", MessageBoxButtons.OK, MessageBoxIcon.Error)
		End Try

		SQLconnect.Close()
	End Sub
	Private Sub SetInComplete(ByVal LabelName As Label, ByVal ButtonName As Button)
		Dim SQLconnect As New SQLite.SQLiteConnection()
		Dim SQLcommand As SQLiteCommand
		'SQLconnect.ConnectionString = "Data Source=" & f.FileName & ";"
		SQLconnect.ConnectionString = "Data Source=.\Database\LotroRaids.sqlite;"
		SQLconnect.Open()
		SQLcommand = SQLconnect.CreateCommand
		'Insert Record into Foo
		'Update Last Created Record in Foo
		Try
			SQLcommand.CommandText = "UPDATE Raids SET DayComplete = '" + Date.Today() + "' WHERE Name = '" + LabelName.Name + "' AND CharacterName = '" + ComboBox1.SelectedItem.ToString.Split("-")(0).Trim + "'"
			'Uncomment this to be able to insert Name fields in to the datbase.
			'SQLcommand.CommandText = "INSERT INTO Raids ('Name','CharacterName') VALUES('" + LabelName.Name + "','" + ComboBox1.SelectedItem.ToString.Split("-")(0).Trim + "'"
			SQLcommand.ExecuteNonQuery()
			SQLcommand.Dispose()
			LabelName.ForeColor = Color.Lime
		Catch ex As Exception
			MessageBox.Show("Please create a character under File -> Add character first.", "No Characters Found!", MessageBoxButtons.OK, MessageBoxIcon.Error)
		End Try

		SQLconnect.Close()
	End Sub
	Private Sub ColorReset()
		Label21st.ForeColor = Color.Lime
		LabelAmonSul.ForeColor = Color.Lime
		LabelAttackAtDawn.ForeColor = Color.Lime
		LabelBarrows.ForeColor = Color.Lime
		LabelBruinen.ForeColor = Color.Lime
		LabelDannenglor.ForeColor = Color.Lime
		LabelDeepWay.ForeColor = Color.Lime
		LabelDraigoch.ForeColor = Color.Lime
		LabelGondamon.ForeColor = Color.Lime
		LabelIcy.ForeColor = Color.Lime
		LabelNecromancer.ForeColor = Color.Lime
		LabelPony.ForeColor = Color.Lime
		LabelRescue.ForeColor = Color.Lime
		LabelRingwraith.ForeColor = Color.Lime
		LabelSmiths.ForeColor = Color.Lime
		LabelThangulhad.ForeColor = Color.Lime
		LabelThievery.ForeColor = Color.Lime
		LabelTowerBattle.ForeColor = Color.Lime
		LabelTuckborough.ForeColor = Color.Lime
		Button21st.Text = "Completed"
		ButtonAmonSul.Text = "Completed"
		ButtonAttackAtDawn.Text = "Completed"
		ButtonBarrows.Text = "Completed"
		ButtonBruinen.Text = "Completed"
		ButtonDannenglor.Text = "Completed"
		ButtonDeepWay.Text = "Completed"
		ButtonDraigoch.Text = "Completed"
		ButtonGondamon.Text = "Completed"
		ButtonIcy.Text = "Completed"
		ButtonNecromancer.Text = "Completed"
		ButtonPony.Text = "Completed"
		ButtonRescue.Text = "Completed"
		ButtonRingwraith.Text = "Completed"
		ButtonSmiths.Text = "Completed"
		ButtonThangulhad.Text = "Completed"
		ButtonThievery.Text = "Completed"
		ButtonTowerBattle.Text = "Completed"
		ButtonTuckborough.Text = "Completed"
	End Sub
	Private Sub LoadStatus()
		Dim Raid(18) As Raid
		If CurrentCharacter IsNot vbNullString Then
			Dim SQLconnect As New SQLite.SQLiteConnection()
			Dim SQLcommand As SQLiteCommand
			SQLconnect.ConnectionString = "Data Source=.\Database\LotroRaids.sqlite;"
			Try
				SQLconnect.Open()
			Catch ex As Exception

			End Try
			SQLcommand = SQLconnect.CreateCommand
			Try
				SQLcommand.CommandText = "Select * from Raids WHERE CharacterName ='" + ComboBox1.SelectedItem.ToString.Split("-")(0).Trim + "'"
			

			Dim SQLreaderRaids As SQLiteDataReader = SQLcommand.ExecuteReader()

			Dim i = 0
			While SQLreaderRaids.Read()
				Raid(i).DayCompleted = SQLreaderRaids("DayComplete")
				Raid(i).Name = SQLreaderRaids("Name")

				If Date.Today < Raid(i).DayCompleted Then
					Select Case Raid(i).Name
						Case "Label21st"
							Label21st.ForeColor = Color.Red
							Button21st.Text = "Not Completed"
						Case "LabelAmonSul"
							LabelAmonSul.ForeColor = Color.Red
							ButtonAmonSul.Text = "Not Completed"
						Case "LabelAttackAtDawn"
							LabelAttackAtDawn.ForeColor = Color.Red
							ButtonAttackAtDawn.Text = "Not Completed"
						Case "LabelBarrows"
							LabelBarrows.ForeColor = Color.Red
							ButtonBarrows.Text = "Not Completed"
						Case "LabelBruinen"
							LabelBruinen.ForeColor = Color.Red
							ButtonBruinen.Text = "Not Completed"
						Case "LabelDannenglor"
							LabelDannenglor.ForeColor = Color.Red
							ButtonDannenglor.Text = "Not Completed"
						Case "LabelDeepWay"
							LabelDeepWay.ForeColor = Color.Red
							ButtonDeepWay.Text = "Not Completed"
						Case "LabelDraigoch"
							LabelDraigoch.ForeColor = Color.Red
							ButtonDraigoch.Text = "Not Completed"
						Case "LabelGondamon"
							LabelGondamon.ForeColor = Color.Red
							ButtonGondamon.Text = "Not Completed"
						Case "LabelIcy"
							LabelIcy.ForeColor = Color.Red
							ButtonIcy.Text = "Not Completed"
						Case "LabelNecromancer"
							LabelNecromancer.ForeColor = Color.Red
							ButtonNecromancer.Text = "Not Completed"
						Case "LabelPony"
							LabelPony.ForeColor = Color.Red
							ButtonPony.Text = "Not Completed"
						Case "LabelRescue"
							LabelRescue.ForeColor = Color.Red
							ButtonRescue.Text = "Not Completed"
						Case "LabelRingwraith"
							LabelRingwraith.ForeColor = Color.Red
							ButtonRingwraith.Text = "Not Completed"
						Case "LabelSmiths"
							LabelSmiths.ForeColor = Color.Red
							ButtonSmiths.Text = "Not Completed"
						Case "LabelThangulhad"
							LabelThangulhad.ForeColor = Color.Red
							ButtonThangulhad.Text = "Not Completed"
						Case "LabelThievery"
							LabelThievery.ForeColor = Color.Red
							ButtonThievery.Text = "Not Completed"
						Case "LabelTowerBattle"
							LabelTowerBattle.ForeColor = Color.Red
							ButtonTowerBattle.Text = "Not Completed"
						Case "LabelTuckborough"
							LabelTuckborough.ForeColor = Color.Red
							ButtonTuckborough.Text = "Not Completed"
					End Select
					End If
				
			i += 1
				End While
			Catch ex As Exception

			End Try
			SQLcommand.Dispose()
		End If

	End Sub
#End Region
	Private Function NextThursday() As DateTime
		Dim dt As DateTime = DateTime.Today
		While dt.DayOfWeek <> DayOfWeek.Thursday
			dt = dt.AddDays(1)
		End While
		Return dt
	End Function

	
	

End Class
