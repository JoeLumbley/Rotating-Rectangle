Imports System.Math

Public Class Form1

    Private angle As Single = 0
    Private timer As Timer

    Dim RectWidth As Integer = 200
    Dim RectHeight As Integer = 100
    Dim halfWidth As Integer = RectWidth / 2
    Dim halfHeight As Integer = RectHeight / 2

    Dim RectPoints As PointF() = {
            New PointF(-halfWidth, -halfHeight),
            New PointF(halfWidth, -halfHeight),
            New PointF(halfWidth, halfHeight),
            New PointF(-halfWidth, halfHeight)
        }

    Dim transformedPoints As PointF() = New PointF(RectPoints.Length - 1) {}

    Public Sub New()
        InitializeComponent()

        ' Initialize Timer
        timer = New Timer()
        AddHandler timer.Tick, AddressOf TimerTick
        timer.Interval = 30
        timer.Start()

        DoubleBuffered = True

    End Sub

    Private Sub TimerTick(sender As Object, e As EventArgs)

        angle += 0.05F

        RotatePoints(RectPoints, angle, New PointF(ClientSize.Width / 2, ClientSize.Height / 2))

        Me.Invalidate() ' Redraw the form

    End Sub

    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        MyBase.OnPaint(e)

        e.Graphics.SmoothingMode = Drawing2D.SmoothingMode.HighQuality

        e.Graphics.FillPolygon(Brushes.Black, transformedPoints)

    End Sub

    Private Sub RotatePoints(points As PointF(), angleInRads As Single, center As PointF)

        For i As Integer = 0 To points.Length - 1

            Dim x As Single = points(i).X * Cos(angleInRads) - points(i).Y * Sin(angleInRads)
            Dim y As Single = points(i).X * Sin(angleInRads) + points(i).Y * Cos(angleInRads)

            transformedPoints(i) = New PointF(x + center.X, y + center.Y)

        Next

    End Sub

End Class
