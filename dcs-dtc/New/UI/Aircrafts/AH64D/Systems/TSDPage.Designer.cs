
using DTC.UI.Base.Controls;

namespace DTC.New.UI.Aircrafts.AH64D.Systems
{
    partial class TSDPage
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            chkShowPresentPosition = new CheckBox();
            toolTip1 = new ToolTip(components);
            chkShowCentered = new CheckBox();
            chkMapShowGrid = new CheckBox();
            chkMapElevationGray = new CheckBox();
            chkNavPhaseShowWptData = new CheckBox();
            chkNavPhaseShowInactiveZones = new CheckBox();
            chkNavPhaseShowObstacles = new CheckBox();
            chkNavPhaseShowOtherStationCursor = new CheckBox();
            chkNavPhaseShowCursorInfo = new CheckBox();
            chkNavPhaseShowHSI = new CheckBox();
            chkNavPhaseShowEndurance = new CheckBox();
            chkNavPhaseShowWind = new CheckBox();
            chkNavPhaseShowControlMeasures = new CheckBox();
            chkNavPhaseShowFriendlyUnits = new CheckBox();
            chkNavPhaseShowEnemyUnits = new CheckBox();
            chkNavPhaseShowTargets = new CheckBox();
            chkAttkPhaseShowCurrentRoute = new CheckBox();
            chkAttkPhaseShowInactiveZones = new CheckBox();
            chkAttkPhaseShowObstacles = new CheckBox();
            chkAttkPhaseShowOtherStationCursor = new CheckBox();
            chkAttkPhaseShowCursorInfo = new CheckBox();
            chkAttkPhaseShowHSI = new CheckBox();
            chkAttkPhaseShowEndurance = new CheckBox();
            chkAttkPhaseShowWind = new CheckBox();
            chkAttkPhaseShowControlMeasures = new CheckBox();
            chkAttkPhaseShowFriendlyUnits = new CheckBox();
            chkAttkPhaseShowEnemyUnits = new CheckBox();
            chkAttkPhaseShowTargets = new CheckBox();
            chkAttkPhaseShowShot = new CheckBox();
            label2 = new Label();
            label1 = new Label();
            chkShowASEThreats = new CheckBox();
            chkShowThreatRings = new CheckBox();
            cboMapType = new DTCDropDown();
            label3 = new Label();
            cboMapOrientation = new DTCDropDown();
            cboMapElevationColorBand = new DTCDropDown();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            SuspendLayout();
            // 
            // chkShowPresentPosition
            // 
            chkShowPresentPosition.Checked = true;
            chkShowPresentPosition.CheckState = CheckState.Checked;
            chkShowPresentPosition.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            chkShowPresentPosition.Location = new Point(15, 41);
            chkShowPresentPosition.Margin = new Padding(4);
            chkShowPresentPosition.Name = "chkShowPresentPosition";
            chkShowPresentPosition.Size = new Size(171, 25);
            chkShowPresentPosition.TabIndex = 0;
            chkShowPresentPosition.Text = "Present Position";
            chkShowPresentPosition.UseVisualStyleBackColor = true;
            // 
            // toolTip1
            // 
            toolTip1.AutomaticDelay = 100;
            toolTip1.AutoPopDelay = 10000;
            toolTip1.InitialDelay = 100;
            toolTip1.IsBalloon = true;
            toolTip1.ReshowDelay = 20;
            // 
            // chkShowCentered
            // 
            chkShowCentered.Checked = true;
            chkShowCentered.CheckState = CheckState.Checked;
            chkShowCentered.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            chkShowCentered.Location = new Point(15, 64);
            chkShowCentered.Margin = new Padding(4);
            chkShowCentered.Name = "chkShowCentered";
            chkShowCentered.Size = new Size(171, 25);
            chkShowCentered.TabIndex = 1;
            chkShowCentered.Text = "Centered";
            chkShowCentered.UseVisualStyleBackColor = true;
            // 
            // chkMapShowGrid
            // 
            chkMapShowGrid.Checked = true;
            chkMapShowGrid.CheckState = CheckState.Checked;
            chkMapShowGrid.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            chkMapShowGrid.Location = new Point(15, 569);
            chkMapShowGrid.Margin = new Padding(4);
            chkMapShowGrid.Name = "chkMapShowGrid";
            chkMapShowGrid.Size = new Size(171, 25);
            chkMapShowGrid.TabIndex = 32;
            chkMapShowGrid.Text = "Grid";
            chkMapShowGrid.UseVisualStyleBackColor = true;
            // 
            // chkMapElevationGray
            // 
            chkMapElevationGray.Checked = true;
            chkMapElevationGray.CheckState = CheckState.Checked;
            chkMapElevationGray.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            chkMapElevationGray.Location = new Point(15, 592);
            chkMapElevationGray.Margin = new Padding(4);
            chkMapElevationGray.Name = "chkMapElevationGray";
            chkMapElevationGray.Size = new Size(171, 25);
            chkMapElevationGray.TabIndex = 33;
            chkMapElevationGray.Text = "Gray Shading";
            chkMapElevationGray.UseVisualStyleBackColor = true;
            // 
            // chkNavPhaseShowWptData
            // 
            chkNavPhaseShowWptData.Checked = true;
            chkNavPhaseShowWptData.CheckState = CheckState.Checked;
            chkNavPhaseShowWptData.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            chkNavPhaseShowWptData.Location = new Point(15, 130);
            chkNavPhaseShowWptData.Margin = new Padding(4);
            chkNavPhaseShowWptData.Name = "chkNavPhaseShowWptData";
            chkNavPhaseShowWptData.Size = new Size(171, 25);
            chkNavPhaseShowWptData.TabIndex = 4;
            chkNavPhaseShowWptData.Text = "Waypoint Data";
            chkNavPhaseShowWptData.UseVisualStyleBackColor = true;
            // 
            // chkNavPhaseShowInactiveZones
            // 
            chkNavPhaseShowInactiveZones.Checked = true;
            chkNavPhaseShowInactiveZones.CheckState = CheckState.Checked;
            chkNavPhaseShowInactiveZones.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            chkNavPhaseShowInactiveZones.Location = new Point(15, 153);
            chkNavPhaseShowInactiveZones.Margin = new Padding(4);
            chkNavPhaseShowInactiveZones.Name = "chkNavPhaseShowInactiveZones";
            chkNavPhaseShowInactiveZones.Size = new Size(171, 25);
            chkNavPhaseShowInactiveZones.TabIndex = 5;
            chkNavPhaseShowInactiveZones.Text = "Inactive Zones";
            chkNavPhaseShowInactiveZones.UseVisualStyleBackColor = true;
            // 
            // chkNavPhaseShowObstacles
            // 
            chkNavPhaseShowObstacles.Checked = true;
            chkNavPhaseShowObstacles.CheckState = CheckState.Checked;
            chkNavPhaseShowObstacles.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            chkNavPhaseShowObstacles.Location = new Point(15, 176);
            chkNavPhaseShowObstacles.Margin = new Padding(4);
            chkNavPhaseShowObstacles.Name = "chkNavPhaseShowObstacles";
            chkNavPhaseShowObstacles.Size = new Size(171, 25);
            chkNavPhaseShowObstacles.TabIndex = 6;
            chkNavPhaseShowObstacles.Text = "Obstacles";
            chkNavPhaseShowObstacles.UseVisualStyleBackColor = true;
            // 
            // chkNavPhaseShowOtherStationCursor
            // 
            chkNavPhaseShowOtherStationCursor.Checked = true;
            chkNavPhaseShowOtherStationCursor.CheckState = CheckState.Checked;
            chkNavPhaseShowOtherStationCursor.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            chkNavPhaseShowOtherStationCursor.Location = new Point(15, 199);
            chkNavPhaseShowOtherStationCursor.Margin = new Padding(4);
            chkNavPhaseShowOtherStationCursor.Name = "chkNavPhaseShowOtherStationCursor";
            chkNavPhaseShowOtherStationCursor.Size = new Size(171, 25);
            chkNavPhaseShowOtherStationCursor.TabIndex = 7;
            chkNavPhaseShowOtherStationCursor.Text = "Other Station Cursor";
            chkNavPhaseShowOtherStationCursor.UseVisualStyleBackColor = true;
            // 
            // chkNavPhaseShowCursorInfo
            // 
            chkNavPhaseShowCursorInfo.Checked = true;
            chkNavPhaseShowCursorInfo.CheckState = CheckState.Checked;
            chkNavPhaseShowCursorInfo.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            chkNavPhaseShowCursorInfo.Location = new Point(15, 222);
            chkNavPhaseShowCursorInfo.Margin = new Padding(4);
            chkNavPhaseShowCursorInfo.Name = "chkNavPhaseShowCursorInfo";
            chkNavPhaseShowCursorInfo.Size = new Size(171, 25);
            chkNavPhaseShowCursorInfo.TabIndex = 8;
            chkNavPhaseShowCursorInfo.Text = "Cursor Info";
            chkNavPhaseShowCursorInfo.UseVisualStyleBackColor = true;
            // 
            // chkNavPhaseShowHSI
            // 
            chkNavPhaseShowHSI.Checked = true;
            chkNavPhaseShowHSI.CheckState = CheckState.Checked;
            chkNavPhaseShowHSI.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            chkNavPhaseShowHSI.Location = new Point(15, 245);
            chkNavPhaseShowHSI.Margin = new Padding(4);
            chkNavPhaseShowHSI.Name = "chkNavPhaseShowHSI";
            chkNavPhaseShowHSI.Size = new Size(171, 25);
            chkNavPhaseShowHSI.TabIndex = 9;
            chkNavPhaseShowHSI.Text = "HSI";
            chkNavPhaseShowHSI.UseVisualStyleBackColor = true;
            // 
            // chkNavPhaseShowEndurance
            // 
            chkNavPhaseShowEndurance.Checked = true;
            chkNavPhaseShowEndurance.CheckState = CheckState.Checked;
            chkNavPhaseShowEndurance.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            chkNavPhaseShowEndurance.Location = new Point(15, 268);
            chkNavPhaseShowEndurance.Margin = new Padding(4);
            chkNavPhaseShowEndurance.Name = "chkNavPhaseShowEndurance";
            chkNavPhaseShowEndurance.Size = new Size(171, 25);
            chkNavPhaseShowEndurance.TabIndex = 10;
            chkNavPhaseShowEndurance.Text = "Endurance";
            chkNavPhaseShowEndurance.UseVisualStyleBackColor = true;
            // 
            // chkNavPhaseShowWind
            // 
            chkNavPhaseShowWind.Checked = true;
            chkNavPhaseShowWind.CheckState = CheckState.Checked;
            chkNavPhaseShowWind.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            chkNavPhaseShowWind.Location = new Point(15, 291);
            chkNavPhaseShowWind.Margin = new Padding(4);
            chkNavPhaseShowWind.Name = "chkNavPhaseShowWind";
            chkNavPhaseShowWind.Size = new Size(171, 25);
            chkNavPhaseShowWind.TabIndex = 11;
            chkNavPhaseShowWind.Text = "Wind";
            chkNavPhaseShowWind.UseVisualStyleBackColor = true;
            // 
            // chkNavPhaseShowControlMeasures
            // 
            chkNavPhaseShowControlMeasures.Checked = true;
            chkNavPhaseShowControlMeasures.CheckState = CheckState.Checked;
            chkNavPhaseShowControlMeasures.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            chkNavPhaseShowControlMeasures.Location = new Point(15, 314);
            chkNavPhaseShowControlMeasures.Margin = new Padding(4);
            chkNavPhaseShowControlMeasures.Name = "chkNavPhaseShowControlMeasures";
            chkNavPhaseShowControlMeasures.Size = new Size(171, 25);
            chkNavPhaseShowControlMeasures.TabIndex = 12;
            chkNavPhaseShowControlMeasures.Text = "Control Measures";
            chkNavPhaseShowControlMeasures.UseVisualStyleBackColor = true;
            // 
            // chkNavPhaseShowFriendlyUnits
            // 
            chkNavPhaseShowFriendlyUnits.Checked = true;
            chkNavPhaseShowFriendlyUnits.CheckState = CheckState.Checked;
            chkNavPhaseShowFriendlyUnits.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            chkNavPhaseShowFriendlyUnits.Location = new Point(15, 337);
            chkNavPhaseShowFriendlyUnits.Margin = new Padding(4);
            chkNavPhaseShowFriendlyUnits.Name = "chkNavPhaseShowFriendlyUnits";
            chkNavPhaseShowFriendlyUnits.Size = new Size(171, 25);
            chkNavPhaseShowFriendlyUnits.TabIndex = 13;
            chkNavPhaseShowFriendlyUnits.Text = "Friendly Units";
            chkNavPhaseShowFriendlyUnits.UseVisualStyleBackColor = true;
            // 
            // chkNavPhaseShowEnemyUnits
            // 
            chkNavPhaseShowEnemyUnits.Checked = true;
            chkNavPhaseShowEnemyUnits.CheckState = CheckState.Checked;
            chkNavPhaseShowEnemyUnits.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            chkNavPhaseShowEnemyUnits.Location = new Point(15, 360);
            chkNavPhaseShowEnemyUnits.Margin = new Padding(4);
            chkNavPhaseShowEnemyUnits.Name = "chkNavPhaseShowEnemyUnits";
            chkNavPhaseShowEnemyUnits.Size = new Size(171, 25);
            chkNavPhaseShowEnemyUnits.TabIndex = 14;
            chkNavPhaseShowEnemyUnits.Text = "Enemy Units";
            chkNavPhaseShowEnemyUnits.UseVisualStyleBackColor = true;
            // 
            // chkNavPhaseShowTargets
            // 
            chkNavPhaseShowTargets.Checked = true;
            chkNavPhaseShowTargets.CheckState = CheckState.Checked;
            chkNavPhaseShowTargets.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            chkNavPhaseShowTargets.Location = new Point(15, 383);
            chkNavPhaseShowTargets.Margin = new Padding(4);
            chkNavPhaseShowTargets.Name = "chkNavPhaseShowTargets";
            chkNavPhaseShowTargets.Size = new Size(171, 25);
            chkNavPhaseShowTargets.TabIndex = 15;
            chkNavPhaseShowTargets.Text = "Targets";
            chkNavPhaseShowTargets.UseVisualStyleBackColor = true;
            // 
            // chkAttkPhaseShowCurrentRoute
            // 
            chkAttkPhaseShowCurrentRoute.Checked = true;
            chkAttkPhaseShowCurrentRoute.CheckState = CheckState.Checked;
            chkAttkPhaseShowCurrentRoute.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            chkAttkPhaseShowCurrentRoute.Location = new Point(241, 130);
            chkAttkPhaseShowCurrentRoute.Margin = new Padding(4);
            chkAttkPhaseShowCurrentRoute.Name = "chkAttkPhaseShowCurrentRoute";
            chkAttkPhaseShowCurrentRoute.Size = new Size(171, 25);
            chkAttkPhaseShowCurrentRoute.TabIndex = 16;
            chkAttkPhaseShowCurrentRoute.Text = "Current Route";
            chkAttkPhaseShowCurrentRoute.UseVisualStyleBackColor = true;
            // 
            // chkAttkPhaseShowInactiveZones
            // 
            chkAttkPhaseShowInactiveZones.Checked = true;
            chkAttkPhaseShowInactiveZones.CheckState = CheckState.Checked;
            chkAttkPhaseShowInactiveZones.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            chkAttkPhaseShowInactiveZones.Location = new Point(241, 153);
            chkAttkPhaseShowInactiveZones.Margin = new Padding(4);
            chkAttkPhaseShowInactiveZones.Name = "chkAttkPhaseShowInactiveZones";
            chkAttkPhaseShowInactiveZones.Size = new Size(171, 25);
            chkAttkPhaseShowInactiveZones.TabIndex = 17;
            chkAttkPhaseShowInactiveZones.Text = "Inactive Zones";
            chkAttkPhaseShowInactiveZones.UseVisualStyleBackColor = true;
            // 
            // chkAttkPhaseShowObstacles
            // 
            chkAttkPhaseShowObstacles.Checked = true;
            chkAttkPhaseShowObstacles.CheckState = CheckState.Checked;
            chkAttkPhaseShowObstacles.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            chkAttkPhaseShowObstacles.Location = new Point(241, 176);
            chkAttkPhaseShowObstacles.Margin = new Padding(4);
            chkAttkPhaseShowObstacles.Name = "chkAttkPhaseShowObstacles";
            chkAttkPhaseShowObstacles.Size = new Size(171, 25);
            chkAttkPhaseShowObstacles.TabIndex = 18;
            chkAttkPhaseShowObstacles.Text = "Obstacles";
            chkAttkPhaseShowObstacles.UseVisualStyleBackColor = true;
            // 
            // chkAttkPhaseShowOtherStationCursor
            // 
            chkAttkPhaseShowOtherStationCursor.Checked = true;
            chkAttkPhaseShowOtherStationCursor.CheckState = CheckState.Checked;
            chkAttkPhaseShowOtherStationCursor.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            chkAttkPhaseShowOtherStationCursor.Location = new Point(241, 199);
            chkAttkPhaseShowOtherStationCursor.Margin = new Padding(4);
            chkAttkPhaseShowOtherStationCursor.Name = "chkAttkPhaseShowOtherStationCursor";
            chkAttkPhaseShowOtherStationCursor.Size = new Size(171, 25);
            chkAttkPhaseShowOtherStationCursor.TabIndex = 19;
            chkAttkPhaseShowOtherStationCursor.Text = "Other Station Cursor";
            chkAttkPhaseShowOtherStationCursor.UseVisualStyleBackColor = true;
            // 
            // chkAttkPhaseShowCursorInfo
            // 
            chkAttkPhaseShowCursorInfo.Checked = true;
            chkAttkPhaseShowCursorInfo.CheckState = CheckState.Checked;
            chkAttkPhaseShowCursorInfo.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            chkAttkPhaseShowCursorInfo.Location = new Point(241, 222);
            chkAttkPhaseShowCursorInfo.Margin = new Padding(4);
            chkAttkPhaseShowCursorInfo.Name = "chkAttkPhaseShowCursorInfo";
            chkAttkPhaseShowCursorInfo.Size = new Size(171, 25);
            chkAttkPhaseShowCursorInfo.TabIndex = 20;
            chkAttkPhaseShowCursorInfo.Text = "Cursor Info";
            chkAttkPhaseShowCursorInfo.UseVisualStyleBackColor = true;
            // 
            // chkAttkPhaseShowHSI
            // 
            chkAttkPhaseShowHSI.Checked = true;
            chkAttkPhaseShowHSI.CheckState = CheckState.Checked;
            chkAttkPhaseShowHSI.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            chkAttkPhaseShowHSI.Location = new Point(241, 245);
            chkAttkPhaseShowHSI.Margin = new Padding(4);
            chkAttkPhaseShowHSI.Name = "chkAttkPhaseShowHSI";
            chkAttkPhaseShowHSI.Size = new Size(171, 25);
            chkAttkPhaseShowHSI.TabIndex = 21;
            chkAttkPhaseShowHSI.Text = "HSI";
            chkAttkPhaseShowHSI.UseVisualStyleBackColor = true;
            // 
            // chkAttkPhaseShowEndurance
            // 
            chkAttkPhaseShowEndurance.Checked = true;
            chkAttkPhaseShowEndurance.CheckState = CheckState.Checked;
            chkAttkPhaseShowEndurance.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            chkAttkPhaseShowEndurance.Location = new Point(241, 268);
            chkAttkPhaseShowEndurance.Margin = new Padding(4);
            chkAttkPhaseShowEndurance.Name = "chkAttkPhaseShowEndurance";
            chkAttkPhaseShowEndurance.Size = new Size(171, 25);
            chkAttkPhaseShowEndurance.TabIndex = 22;
            chkAttkPhaseShowEndurance.Text = "Endurance";
            chkAttkPhaseShowEndurance.UseVisualStyleBackColor = true;
            // 
            // chkAttkPhaseShowWind
            // 
            chkAttkPhaseShowWind.Checked = true;
            chkAttkPhaseShowWind.CheckState = CheckState.Checked;
            chkAttkPhaseShowWind.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            chkAttkPhaseShowWind.Location = new Point(241, 291);
            chkAttkPhaseShowWind.Margin = new Padding(4);
            chkAttkPhaseShowWind.Name = "chkAttkPhaseShowWind";
            chkAttkPhaseShowWind.Size = new Size(171, 25);
            chkAttkPhaseShowWind.TabIndex = 23;
            chkAttkPhaseShowWind.Text = "Wind";
            chkAttkPhaseShowWind.UseVisualStyleBackColor = true;
            // 
            // chkAttkPhaseShowControlMeasures
            // 
            chkAttkPhaseShowControlMeasures.Checked = true;
            chkAttkPhaseShowControlMeasures.CheckState = CheckState.Checked;
            chkAttkPhaseShowControlMeasures.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            chkAttkPhaseShowControlMeasures.Location = new Point(241, 314);
            chkAttkPhaseShowControlMeasures.Margin = new Padding(4);
            chkAttkPhaseShowControlMeasures.Name = "chkAttkPhaseShowControlMeasures";
            chkAttkPhaseShowControlMeasures.Size = new Size(171, 25);
            chkAttkPhaseShowControlMeasures.TabIndex = 24;
            chkAttkPhaseShowControlMeasures.Text = "Control Measures";
            chkAttkPhaseShowControlMeasures.UseVisualStyleBackColor = true;
            // 
            // chkAttkPhaseShowFriendlyUnits
            // 
            chkAttkPhaseShowFriendlyUnits.Checked = true;
            chkAttkPhaseShowFriendlyUnits.CheckState = CheckState.Checked;
            chkAttkPhaseShowFriendlyUnits.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            chkAttkPhaseShowFriendlyUnits.Location = new Point(241, 337);
            chkAttkPhaseShowFriendlyUnits.Margin = new Padding(4);
            chkAttkPhaseShowFriendlyUnits.Name = "chkAttkPhaseShowFriendlyUnits";
            chkAttkPhaseShowFriendlyUnits.Size = new Size(171, 25);
            chkAttkPhaseShowFriendlyUnits.TabIndex = 25;
            chkAttkPhaseShowFriendlyUnits.Text = "Friendly Units";
            chkAttkPhaseShowFriendlyUnits.UseVisualStyleBackColor = true;
            // 
            // chkAttkPhaseShowEnemyUnits
            // 
            chkAttkPhaseShowEnemyUnits.Checked = true;
            chkAttkPhaseShowEnemyUnits.CheckState = CheckState.Checked;
            chkAttkPhaseShowEnemyUnits.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            chkAttkPhaseShowEnemyUnits.Location = new Point(241, 360);
            chkAttkPhaseShowEnemyUnits.Margin = new Padding(4);
            chkAttkPhaseShowEnemyUnits.Name = "chkAttkPhaseShowEnemyUnits";
            chkAttkPhaseShowEnemyUnits.Size = new Size(171, 25);
            chkAttkPhaseShowEnemyUnits.TabIndex = 26;
            chkAttkPhaseShowEnemyUnits.Text = "Enemy Units";
            chkAttkPhaseShowEnemyUnits.UseVisualStyleBackColor = true;
            // 
            // chkAttkPhaseShowTargets
            // 
            chkAttkPhaseShowTargets.Checked = true;
            chkAttkPhaseShowTargets.CheckState = CheckState.Checked;
            chkAttkPhaseShowTargets.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            chkAttkPhaseShowTargets.Location = new Point(241, 383);
            chkAttkPhaseShowTargets.Margin = new Padding(4);
            chkAttkPhaseShowTargets.Name = "chkAttkPhaseShowTargets";
            chkAttkPhaseShowTargets.Size = new Size(171, 25);
            chkAttkPhaseShowTargets.TabIndex = 27;
            chkAttkPhaseShowTargets.Text = "Targets";
            chkAttkPhaseShowTargets.UseVisualStyleBackColor = true;
            // 
            // chkAttkPhaseShowShot
            // 
            chkAttkPhaseShowShot.Checked = true;
            chkAttkPhaseShowShot.CheckState = CheckState.Checked;
            chkAttkPhaseShowShot.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            chkAttkPhaseShowShot.Location = new Point(241, 406);
            chkAttkPhaseShowShot.Margin = new Padding(4);
            chkAttkPhaseShowShot.Name = "chkAttkPhaseShowShot";
            chkAttkPhaseShowShot.Size = new Size(171, 25);
            chkAttkPhaseShowShot.TabIndex = 28;
            chkAttkPhaseShowShot.Text = "Shot";
            chkAttkPhaseShowShot.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(7, 101);
            label2.Margin = new Padding(0);
            label2.Name = "label2";
            label2.Padding = new Padding(5, 0, 0, 0);
            label2.Size = new Size(179, 25);
            label2.TabIndex = 16;
            label2.Text = "Nav Phase Settings";
            label2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            label1.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(235, 101);
            label1.Margin = new Padding(0);
            label1.Name = "label1";
            label1.Padding = new Padding(5, 0, 0, 0);
            label1.Size = new Size(187, 25);
            label1.TabIndex = 16;
            label1.Text = "Attack Phase Settings";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // chkShowASEThreats
            // 
            chkShowASEThreats.Checked = true;
            chkShowASEThreats.CheckState = CheckState.Checked;
            chkShowASEThreats.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            chkShowASEThreats.Location = new Point(241, 41);
            chkShowASEThreats.Margin = new Padding(4);
            chkShowASEThreats.Name = "chkShowASEThreats";
            chkShowASEThreats.Size = new Size(171, 25);
            chkShowASEThreats.TabIndex = 2;
            chkShowASEThreats.Text = "Show ASE Threats";
            chkShowASEThreats.UseVisualStyleBackColor = true;
            // 
            // chkShowThreatRings
            // 
            chkShowThreatRings.Checked = true;
            chkShowThreatRings.CheckState = CheckState.Checked;
            chkShowThreatRings.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            chkShowThreatRings.Location = new Point(241, 64);
            chkShowThreatRings.Margin = new Padding(4);
            chkShowThreatRings.Name = "chkShowThreatRings";
            chkShowThreatRings.Size = new Size(171, 25);
            chkShowThreatRings.TabIndex = 3;
            chkShowThreatRings.Text = "Show Threat Rings";
            chkShowThreatRings.UseVisualStyleBackColor = true;
            // 
            // cboMapType
            // 
            cboMapType.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cboMapType.DropDownStyle = ComboBoxStyle.DropDownList;
            cboMapType.FlatStyle = FlatStyle.Flat;
            cboMapType.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            cboMapType.FormattingEnabled = true;
            cboMapType.Location = new Point(193, 472);
            cboMapType.Name = "cboMapType";
            cboMapType.Size = new Size(219, 24);
            cboMapType.TabIndex = 29;
            // 
            // label3
            // 
            label3.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(7, 472);
            label3.Margin = new Padding(0);
            label3.Name = "label3";
            label3.Padding = new Padding(5, 0, 0, 0);
            label3.Size = new Size(150, 25);
            label3.TabIndex = 16;
            label3.Text = "Type:";
            label3.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // cboMapOrientation
            // 
            cboMapOrientation.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cboMapOrientation.DropDownStyle = ComboBoxStyle.DropDownList;
            cboMapOrientation.FlatStyle = FlatStyle.Flat;
            cboMapOrientation.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            cboMapOrientation.FormattingEnabled = true;
            cboMapOrientation.Location = new Point(193, 502);
            cboMapOrientation.Name = "cboMapOrientation";
            cboMapOrientation.Size = new Size(219, 24);
            cboMapOrientation.TabIndex = 30;
            // 
            // cboMapElevationColorBand
            // 
            cboMapElevationColorBand.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cboMapElevationColorBand.DropDownStyle = ComboBoxStyle.DropDownList;
            cboMapElevationColorBand.FlatStyle = FlatStyle.Flat;
            cboMapElevationColorBand.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            cboMapElevationColorBand.FormattingEnabled = true;
            cboMapElevationColorBand.Location = new Point(193, 532);
            cboMapElevationColorBand.Name = "cboMapElevationColorBand";
            cboMapElevationColorBand.Size = new Size(219, 24);
            cboMapElevationColorBand.TabIndex = 31;
            // 
            // label4
            // 
            label4.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(7, 501);
            label4.Margin = new Padding(0);
            label4.Name = "label4";
            label4.Padding = new Padding(5, 0, 0, 0);
            label4.Size = new Size(150, 25);
            label4.TabIndex = 16;
            label4.Text = "Orientation:";
            label4.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            label5.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(7, 531);
            label5.Margin = new Padding(0);
            label5.Name = "label5";
            label5.Padding = new Padding(5, 0, 0, 0);
            label5.Size = new Size(150, 25);
            label5.TabIndex = 16;
            label5.Text = "Color Band:";
            label5.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            label6.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold, GraphicsUnit.Point);
            label6.Location = new Point(7, 445);
            label6.Margin = new Padding(0);
            label6.Name = "label6";
            label6.Padding = new Padding(5, 0, 0, 0);
            label6.Size = new Size(150, 25);
            label6.TabIndex = 16;
            label6.Text = "Map Settings";
            label6.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            label7.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold, GraphicsUnit.Point);
            label7.Location = new Point(7, 12);
            label7.Margin = new Padding(0);
            label7.Name = "label7";
            label7.Padding = new Padding(5, 0, 0, 0);
            label7.Size = new Size(150, 25);
            label7.TabIndex = 16;
            label7.Text = "General Settings";
            label7.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // TSDPage
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            AutoScroll = true;
            AutoScrollMargin = new Size(0, 15);
            BackColor = Color.PaleGoldenrod;
            Controls.Add(cboMapElevationColorBand);
            Controls.Add(cboMapOrientation);
            Controls.Add(cboMapType);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label1);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label2);
            Controls.Add(chkAttkPhaseShowShot);
            Controls.Add(chkAttkPhaseShowTargets);
            Controls.Add(chkNavPhaseShowTargets);
            Controls.Add(chkAttkPhaseShowEnemyUnits);
            Controls.Add(chkNavPhaseShowEnemyUnits);
            Controls.Add(chkAttkPhaseShowFriendlyUnits);
            Controls.Add(chkNavPhaseShowFriendlyUnits);
            Controls.Add(chkAttkPhaseShowControlMeasures);
            Controls.Add(chkNavPhaseShowControlMeasures);
            Controls.Add(chkAttkPhaseShowWind);
            Controls.Add(chkNavPhaseShowWind);
            Controls.Add(chkAttkPhaseShowEndurance);
            Controls.Add(chkNavPhaseShowEndurance);
            Controls.Add(chkAttkPhaseShowHSI);
            Controls.Add(chkNavPhaseShowHSI);
            Controls.Add(chkAttkPhaseShowCursorInfo);
            Controls.Add(chkNavPhaseShowCursorInfo);
            Controls.Add(chkAttkPhaseShowOtherStationCursor);
            Controls.Add(chkNavPhaseShowOtherStationCursor);
            Controls.Add(chkAttkPhaseShowObstacles);
            Controls.Add(chkNavPhaseShowObstacles);
            Controls.Add(chkAttkPhaseShowInactiveZones);
            Controls.Add(chkNavPhaseShowInactiveZones);
            Controls.Add(chkAttkPhaseShowCurrentRoute);
            Controls.Add(chkNavPhaseShowWptData);
            Controls.Add(chkShowThreatRings);
            Controls.Add(chkShowASEThreats);
            Controls.Add(chkMapElevationGray);
            Controls.Add(chkMapShowGrid);
            Controls.Add(chkShowCentered);
            Controls.Add(chkShowPresentPosition);
            Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Margin = new Padding(4);
            Name = "TSDPage";
            Size = new Size(636, 787);
            ResumeLayout(false);
        }

        #endregion
        private CheckBox chkShowPresentPosition;
        private ToolTip toolTip1;
        private CheckBox chkShowCentered;
        private CheckBox chkMapShowGrid;
        private CheckBox chkMapElevationGray;
        private CheckBox chkNavPhaseShowWptData;
        private CheckBox chkNavPhaseShowInactiveZones;
        private CheckBox chkNavPhaseShowObstacles;
        private CheckBox chkNavPhaseShowOtherStationCursor;
        private CheckBox chkNavPhaseShowCursorInfo;
        private CheckBox chkNavPhaseShowHSI;
        private CheckBox chkNavPhaseShowEndurance;
        private CheckBox chkNavPhaseShowWind;
        private CheckBox chkNavPhaseShowControlMeasures;
        private CheckBox chkNavPhaseShowFriendlyUnits;
        private CheckBox chkNavPhaseShowEnemyUnits;
        private CheckBox chkNavPhaseShowTargets;
        private CheckBox chkAttkPhaseShowCurrentRoute;
        private CheckBox chkAttkPhaseShowInactiveZones;
        private CheckBox chkAttkPhaseShowObstacles;
        private CheckBox chkAttkPhaseShowOtherStationCursor;
        private CheckBox chkAttkPhaseShowCursorInfo;
        private CheckBox chkAttkPhaseShowHSI;
        private CheckBox chkAttkPhaseShowEndurance;
        private CheckBox chkAttkPhaseShowWind;
        private CheckBox chkAttkPhaseShowControlMeasures;
        private CheckBox chkAttkPhaseShowFriendlyUnits;
        private CheckBox chkAttkPhaseShowEnemyUnits;
        private CheckBox chkAttkPhaseShowTargets;
        private CheckBox chkAttkPhaseShowShot;
        private Label label2;
        private Label label1;
        private CheckBox chkShowASEThreats;
        private CheckBox chkShowThreatRings;
        protected DTCDropDown cboMapType;
        private Label label3;
        protected DTCDropDown cboMapOrientation;
        protected DTCDropDown cboMapElevationColorBand;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
    }
}
