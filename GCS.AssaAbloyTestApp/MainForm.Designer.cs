namespace GCS.AssaAbloyTestApp
{
    partial class MainForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnListAccessPoints = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkUseEncryption = new System.Windows.Forms.CheckBox();
            this.btnRemoveAllAccessPoints = new System.Windows.Forms.Button();
            this.lblAccessPointCount = new System.Windows.Forms.Label();
            this.label44 = new System.Windows.Forms.Label();
            this.label34 = new System.Windows.Forms.Label();
            this.txtCallbackPort = new System.Windows.Forms.TextBox();
            this.label33 = new System.Windows.Forms.Label();
            this.txtCallbackAddress = new System.Windows.Forms.TextBox();
            this.txtAccessPointDescription = new System.Windows.Forms.TextBox();
            this.label32 = new System.Windows.Forms.Label();
            this.btnAddReaderDescription = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.txtDSRIpAddress = new System.Windows.Forms.TextBox();
            this.txtAddAccessPointSerialNumber = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnEnableAccessPoint = new System.Windows.Forms.Button();
            this.btnDisableAccessPoint = new System.Windows.Forms.Button();
            this.btnAddAndConfirmAccessPoint = new System.Windows.Forms.Button();
            this.btnReplaceAccessPoint = new System.Windows.Forms.Button();
            this.btnClearAccessPoint = new System.Windows.Forms.Button();
            this.btnRemoveAccessPoint = new System.Windows.Forms.Button();
            this.btnSetAccessPointEndpointParams = new System.Windows.Forms.Button();
            this.btnGetStatus = new System.Windows.Forms.Button();
            this.btnGetVersionInfo = new System.Windows.Forms.Button();
            this.btnGetSupportedCredentialFormats = new System.Windows.Forms.Button();
            this.btnUnregisterCallback = new System.Windows.Forms.Button();
            this.btnListCallbackEndpoints = new System.Windows.Forms.Button();
            this.btnRegisterCallback = new System.Windows.Forms.Button();
            this.btnConfirmAccessPoint = new System.Windows.Forms.Button();
            this.btnVerifyAccessPointOnline = new System.Windows.Forms.Button();
            this.btnFindAccessPointBySerialNumber = new System.Windows.Forms.Button();
            this.btnGetAccessPointStatus = new System.Windows.Forms.Button();
            this.cbAccessPointsOnline = new System.Windows.Forms.ComboBox();
            this.btnListAccessPointsOnline = new System.Windows.Forms.Button();
            this.cbAccessPointsByType = new System.Windows.Forms.ComboBox();
            this.cbAccessPointTypes = new System.Windows.Forms.ComboBox();
            this.btnGetAccessPointTypes = new System.Windows.Forms.Button();
            this.cbAllAccessPoints = new System.Windows.Forms.ComboBox();
            this.btnListAllAccessPoints = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPageUsers = new System.Windows.Forms.TabPage();
            this.lblUserCount = new System.Windows.Forms.Label();
            this.txtCredentialPINStringValue = new System.Windows.Forms.TextBox();
            this.label42 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.cbUserAuthorizationSchedule = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cbUserAuthorizationType = new System.Windows.Forms.ComboBox();
            this.label26 = new System.Windows.Forms.Label();
            this.clbUserAuthorizeAccessPoints = new System.Windows.Forms.CheckedListBox();
            this.cbUserIds = new System.Windows.Forms.ComboBox();
            this.txtCredentialIntegerValue = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtCredentialFacilityCode = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtCredentialStringValue = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.cbCredentialFormats = new System.Windows.Forms.ComboBox();
            this.btnRemoveUserCascading = new System.Windows.Forms.Button();
            this.btnModifyUser = new System.Windows.Forms.Button();
            this.btnRemoveUser = new System.Windows.Forms.Button();
            this.btnGetUserIds = new System.Windows.Forms.Button();
            this.chkUserSuspended = new System.Windows.Forms.CheckBox();
            this.chkUserExtended = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.dtpUserValidUntil = new System.Windows.Forms.DateTimePicker();
            this.dtpUserValidFrom = new System.Windows.Forms.DateTimePicker();
            this.btnAddUser = new System.Windows.Forms.Button();
            this.tabPageDayPeriods = new System.Windows.Forms.TabPage();
            this.btnDayPeriodAddTimePeriod = new System.Windows.Forms.Button();
            this.clbDayPeriodTimePeriods = new System.Windows.Forms.CheckedListBox();
            this.btnModifyDayPeriod = new System.Windows.Forms.Button();
            this.btnRemoveDayPeriod = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.dayPeriodEndTime = new System.Windows.Forms.DateTimePicker();
            this.dayPeriodStartTime = new System.Windows.Forms.DateTimePicker();
            this.WeekDayCheckBoxList = new System.Windows.Forms.CheckedListBox();
            this.cbDayPeriodIdList = new System.Windows.Forms.ComboBox();
            this.btnAddDayPeriod = new System.Windows.Forms.Button();
            this.btnGetDayPeriodIds = new System.Windows.Forms.Button();
            this.tabPageDayExceptions = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnRemoveDayExceptionFromDayExceptionGroup = new System.Windows.Forms.Button();
            this.btnAddDayExceptionToDayExceptionGroup = new System.Windows.Forms.Button();
            this.label20 = new System.Windows.Forms.Label();
            this.btnModifyDayExceptionGroup = new System.Windows.Forms.Button();
            this.clbDayExceptionGroupsDayExceptionIdList = new System.Windows.Forms.CheckedListBox();
            this.btnRemoveDayExceptionGroup = new System.Windows.Forms.Button();
            this.btnGetDayExceptionGroupIds = new System.Windows.Forms.Button();
            this.cbDayExceptionGroupIdList = new System.Windows.Forms.ComboBox();
            this.btnAddDayExceptionGroup = new System.Windows.Forms.Button();
            this.ucDayExceptionViewControl = new GCS.AssaAbloyTestApp.ucDayExceptionViewControl();
            this.btnDayExceptionAddTimePeriod = new System.Windows.Forms.Button();
            this.clbDayExceptionTimePeriods = new System.Windows.Forms.CheckedListBox();
            this.dtpDayExceptionEndTime = new System.Windows.Forms.DateTimePicker();
            this.dtpDayExceptionStartTime = new System.Windows.Forms.DateTimePicker();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.dtpDayExceptionDate = new System.Windows.Forms.DateTimePicker();
            this.btnModifyDayException = new System.Windows.Forms.Button();
            this.btnRemoveDayException = new System.Windows.Forms.Button();
            this.cbDayExceptionIdList = new System.Windows.Forms.ComboBox();
            this.btnAddDayException = new System.Windows.Forms.Button();
            this.btnGetDayExceptionIds = new System.Windows.Forms.Button();
            this.tabPageSchedules = new System.Windows.Forms.TabPage();
            this.btnRemoveDayExceptionGroupFromSchedule = new System.Windows.Forms.Button();
            this.btnAddDayExceptionGroupToSchedule = new System.Windows.Forms.Button();
            this.btnRemoveDayPeriodFromSchedule = new System.Windows.Forms.Button();
            this.btnAddDayPeriodToSchedule = new System.Windows.Forms.Button();
            this.label22 = new System.Windows.Forms.Label();
            this.ucScheduleDayExceptionViewControl = new GCS.AssaAbloyTestApp.ucDayExceptionViewControl();
            this.lbScheduleDayExceptionGroupDayExceptions = new System.Windows.Forms.ListBox();
            this.label21 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.scheduleDayPeriodViewControl = new GCS.AssaAbloyTestApp.DayPeriodViewControl();
            this.clbScheduleDayExceptionGroupIdList = new System.Windows.Forms.CheckedListBox();
            this.clbScheduleDayPeriodCheckedListBox = new System.Windows.Forms.CheckedListBox();
            this.btnModifySchedule = new System.Windows.Forms.Button();
            this.btnRemoveSchedule = new System.Windows.Forms.Button();
            this.cbScheduleIdList = new System.Windows.Forms.ComboBox();
            this.btnAddSchedule = new System.Windows.Forms.Button();
            this.btnGetScheduleIds = new System.Windows.Forms.Button();
            this.tabPageAuthorizations = new System.Windows.Forms.TabPage();
            this.txtToggleAuthIncCount = new System.Windows.Forms.TextBox();
            this.btnToggleAllAccessPointsAuthorization = new System.Windows.Forms.Button();
            this.btnToggleAllUsersAuthorization = new System.Windows.Forms.Button();
            this.label43 = new System.Windows.Forms.Label();
            this.txtUseCount = new System.Windows.Forms.TextBox();
            this.btnSetAuthorizationTypeForAuthorization = new System.Windows.Forms.Button();
            this.btnSetNewScheduleInAuthorization = new System.Windows.Forms.Button();
            this.btnremoveAccessPointsFromAuthorization = new System.Windows.Forms.Button();
            this.btnaddAccessPointsToAuthorization = new System.Windows.Forms.Button();
            this.btnremoveUsersFromAuthorization = new System.Windows.Forms.Button();
            this.btnaddUsersToAuthorization = new System.Windows.Forms.Button();
            this.label30 = new System.Windows.Forms.Label();
            this.cbAuthorizationAuthorizationSchedule = new System.Windows.Forms.ComboBox();
            this.label31 = new System.Windows.Forms.Label();
            this.cbAuthorizationAuthorizationType = new System.Windows.Forms.ComboBox();
            this.label29 = new System.Windows.Forms.Label();
            this.clbAuthorizationAuthorizeUsers = new System.Windows.Forms.CheckedListBox();
            this.label28 = new System.Windows.Forms.Label();
            this.clbAuthorizationAuthorizeAccessPoints = new System.Windows.Forms.CheckedListBox();
            this.btnModifyAuthorization = new System.Windows.Forms.Button();
            this.btnRemoveAuthorization = new System.Windows.Forms.Button();
            this.cbAuthorizationIdList = new System.Windows.Forms.ComboBox();
            this.btnAddAuthorization = new System.Windows.Forms.Button();
            this.btnAuthorizeAllUsersAllLocks = new System.Windows.Forms.Button();
            this.btnGetAuthorizationIds = new System.Windows.Forms.Button();
            this.tabPageAccessPointSpecificOperations = new System.Windows.Forms.TabPage();
            this.btnACGetNewLogsRepeatForDSR = new System.Windows.Forms.Button();
            this.tabControl3 = new System.Windows.Forms.TabControl();
            this.tabPageAlarms = new System.Windows.Forms.TabPage();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label38 = new System.Windows.Forms.Label();
            this.btnSetFilters = new System.Windows.Forms.Button();
            this.label37 = new System.Windows.Forms.Label();
            this.label36 = new System.Windows.Forms.Label();
            this.clbRXHeldModeAlarms = new System.Windows.Forms.CheckedListBox();
            this.clbPassageModeAlarms = new System.Windows.Forms.CheckedListBox();
            this.clbSecuredModeAlarms = new System.Windows.Forms.CheckedListBox();
            this.btnSetAlarms = new System.Windows.Forms.Button();
            this.tabPageFilters = new System.Windows.Forms.TabPage();
            this.tabPageScheduler = new System.Windows.Forms.TabPage();
            this.btnSetAccessPointSchedulerSimple = new System.Windows.Forms.Button();
            this.label41 = new System.Windows.Forms.Label();
            this.txtAccessPointSimpleConnectMinutes = new System.Windows.Forms.TextBox();
            this.label40 = new System.Windows.Forms.Label();
            this.btnLoadAccessPointSchedulerData = new System.Windows.Forms.Button();
            this.cbAccessPointScheduler = new System.Windows.Forms.ComboBox();
            this.label39 = new System.Windows.Forms.Label();
            this.btnACGetNewLogsRepeat = new System.Windows.Forms.Button();
            this.btnSetAllLocksAccessPrimaryOnlyMode = new System.Windows.Forms.Button();
            this.grpAccessControlAccessPointOperations = new System.Windows.Forms.GroupBox();
            this.label35 = new System.Windows.Forms.Label();
            this.txtUnlockTime = new System.Windows.Forms.TextBox();
            this.btnSetUnlockTime = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnRemoveAllAuthorizationsFromAccessPoint = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.dpGetLogsByDateEndTime = new System.Windows.Forms.DateTimePicker();
            this.dpGetLogsByDateStartTime = new System.Windows.Forms.DateTimePicker();
            this.btnGetLogsByDate = new System.Windows.Forms.Button();
            this.btnReloadAccessPointProvisioningData = new System.Windows.Forms.Button();
            this.btnSetDateTime = new System.Windows.Forms.Button();
            this.btnGetDateTime = new System.Windows.Forms.Button();
            this.btnLock = new System.Windows.Forms.Button();
            this.btnUnlock = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPulseTime = new System.Windows.Forms.TextBox();
            this.btnPulseOpen = new System.Windows.Forms.Button();
            this.btnACGetNewLogs = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cbAccessControlServiceAccessPoints = new System.Windows.Forms.ComboBox();
            this.tabPageAccessPointModes = new System.Windows.Forms.TabPage();
            this.cbAccessPointModeSchedulesList = new System.Windows.Forms.ComboBox();
            this.cbAccessPointModeType = new System.Windows.Forms.ComboBox();
            this.label25 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.clbAccessPointModeAccessPointList = new System.Windows.Forms.CheckedListBox();
            this.btnModifyAccessPointMode = new System.Windows.Forms.Button();
            this.btnRemoveAccessPointMode = new System.Windows.Forms.Button();
            this.btnGetAccessPointModeIds = new System.Windows.Forms.Button();
            this.cbAccessPointModeIdList = new System.Windows.Forms.ComboBox();
            this.btnAddAccessPointMode = new System.Windows.Forms.Button();
            this.btnClearAll = new System.Windows.Forms.Button();
            this.btnDeleteAllOrphanEntities = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageManagementService = new System.Windows.Forms.TabPage();
            this.tabPageAccessControlService = new System.Windows.Forms.TabPage();
            this.tabPageCallbackService = new System.Windows.Forms.TabPage();
            this.eventTextBox = new System.Windows.Forms.RichTextBox();
            this.tabPageSupportService = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPageInformation = new System.Windows.Forms.TabPage();
            this.txtInformation = new System.Windows.Forms.RichTextBox();
            this.tabPageErrors = new System.Windows.Forms.TabPage();
            this.txtErrors = new System.Windows.Forms.RichTextBox();
            this.btnFindUserByCardNumbers = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabPageUsers.SuspendLayout();
            this.tabPageDayPeriods.SuspendLayout();
            this.tabPageDayExceptions.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tabPageSchedules.SuspendLayout();
            this.tabPageAuthorizations.SuspendLayout();
            this.tabPageAccessPointSpecificOperations.SuspendLayout();
            this.tabControl3.SuspendLayout();
            this.tabPageAlarms.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.tabPageScheduler.SuspendLayout();
            this.grpAccessControlAccessPointOperations.SuspendLayout();
            this.tabPageAccessPointModes.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPageManagementService.SuspendLayout();
            this.tabPageAccessControlService.SuspendLayout();
            this.tabPageCallbackService.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabPageInformation.SuspendLayout();
            this.tabPageErrors.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnListAccessPoints
            // 
            this.btnListAccessPoints.Enabled = false;
            this.btnListAccessPoints.Location = new System.Drawing.Point(7, 220);
            this.btnListAccessPoints.Name = "btnListAccessPoints";
            this.btnListAccessPoints.Size = new System.Drawing.Size(224, 23);
            this.btnListAccessPoints.TabIndex = 1;
            this.btnListAccessPoints.Text = "listAccessPoints (by type)";
            this.btnListAccessPoints.UseVisualStyleBackColor = true;
            this.btnListAccessPoints.Click += new System.EventHandler(this.btnListAccessPoints_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.chkUseEncryption);
            this.groupBox1.Controls.Add(this.btnRemoveAllAccessPoints);
            this.groupBox1.Controls.Add(this.lblAccessPointCount);
            this.groupBox1.Controls.Add(this.label44);
            this.groupBox1.Controls.Add(this.label34);
            this.groupBox1.Controls.Add(this.txtCallbackPort);
            this.groupBox1.Controls.Add(this.label33);
            this.groupBox1.Controls.Add(this.txtCallbackAddress);
            this.groupBox1.Controls.Add(this.txtAccessPointDescription);
            this.groupBox1.Controls.Add(this.label32);
            this.groupBox1.Controls.Add(this.btnAddReaderDescription);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.txtDSRIpAddress);
            this.groupBox1.Controls.Add(this.txtAddAccessPointSerialNumber);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnEnableAccessPoint);
            this.groupBox1.Controls.Add(this.btnDisableAccessPoint);
            this.groupBox1.Controls.Add(this.btnAddAndConfirmAccessPoint);
            this.groupBox1.Controls.Add(this.btnReplaceAccessPoint);
            this.groupBox1.Controls.Add(this.btnClearAccessPoint);
            this.groupBox1.Controls.Add(this.btnRemoveAccessPoint);
            this.groupBox1.Controls.Add(this.btnSetAccessPointEndpointParams);
            this.groupBox1.Controls.Add(this.btnGetStatus);
            this.groupBox1.Controls.Add(this.btnGetVersionInfo);
            this.groupBox1.Controls.Add(this.btnGetSupportedCredentialFormats);
            this.groupBox1.Controls.Add(this.btnUnregisterCallback);
            this.groupBox1.Controls.Add(this.btnListCallbackEndpoints);
            this.groupBox1.Controls.Add(this.btnRegisterCallback);
            this.groupBox1.Controls.Add(this.btnConfirmAccessPoint);
            this.groupBox1.Controls.Add(this.btnVerifyAccessPointOnline);
            this.groupBox1.Controls.Add(this.btnFindAccessPointBySerialNumber);
            this.groupBox1.Controls.Add(this.btnGetAccessPointStatus);
            this.groupBox1.Controls.Add(this.cbAccessPointsOnline);
            this.groupBox1.Controls.Add(this.btnListAccessPointsOnline);
            this.groupBox1.Controls.Add(this.cbAccessPointsByType);
            this.groupBox1.Controls.Add(this.cbAccessPointTypes);
            this.groupBox1.Controls.Add(this.btnGetAccessPointTypes);
            this.groupBox1.Controls.Add(this.cbAllAccessPoints);
            this.groupBox1.Controls.Add(this.btnListAllAccessPoints);
            this.groupBox1.Controls.Add(this.btnListAccessPoints);
            this.groupBox1.Location = new System.Drawing.Point(6, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1044, 662);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Management Service";
            // 
            // chkUseEncryption
            // 
            this.chkUseEncryption.AutoSize = true;
            this.chkUseEncryption.Location = new System.Drawing.Point(858, 114);
            this.chkUseEncryption.Name = "chkUseEncryption";
            this.chkUseEncryption.Size = new System.Drawing.Size(98, 17);
            this.chkUseEncryption.TabIndex = 40;
            this.chkUseEncryption.Text = "Use Encryption";
            this.chkUseEncryption.UseVisualStyleBackColor = true;
            this.chkUseEncryption.Click += new System.EventHandler(this.chkUseEncryption_Click);
            // 
            // btnRemoveAllAccessPoints
            // 
            this.btnRemoveAllAccessPoints.Location = new System.Drawing.Point(653, 133);
            this.btnRemoveAllAccessPoints.Name = "btnRemoveAllAccessPoints";
            this.btnRemoveAllAccessPoints.Size = new System.Drawing.Size(178, 23);
            this.btnRemoveAllAccessPoints.TabIndex = 39;
            this.btnRemoveAllAccessPoints.Text = "Remove ALL Access Points";
            this.btnRemoveAllAccessPoints.UseVisualStyleBackColor = true;
            this.btnRemoveAllAccessPoints.Click += new System.EventHandler(this.btnRemoveAllAccessPoints_Click);
            // 
            // lblAccessPointCount
            // 
            this.lblAccessPointCount.AutoSize = true;
            this.lblAccessPointCount.Location = new System.Drawing.Point(115, 114);
            this.lblAccessPointCount.Name = "lblAccessPointCount";
            this.lblAccessPointCount.Size = new System.Drawing.Size(0, 13);
            this.lblAccessPointCount.TabIndex = 38;
            // 
            // label44
            // 
            this.label44.AutoSize = true;
            this.label44.Location = new System.Drawing.Point(6, 114);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(103, 13);
            this.label44.TabIndex = 37;
            this.label44.Text = "Access Point Count:";
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Location = new System.Drawing.Point(962, 69);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(36, 13);
            this.label34.TabIndex = 36;
            this.label34.Text = "Port #";
            // 
            // txtCallbackPort
            // 
            this.txtCallbackPort.Location = new System.Drawing.Point(964, 85);
            this.txtCallbackPort.Name = "txtCallbackPort";
            this.txtCallbackPort.Size = new System.Drawing.Size(42, 20);
            this.txtCallbackPort.TabIndex = 35;
            this.txtCallbackPort.Text = "9091";
            this.txtCallbackPort.TextChanged += new System.EventHandler(this.txtCallbackPort_TextChanged);
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(855, 69);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(92, 13);
            this.label33.TabIndex = 34;
            this.label33.Text = "Callback Address:";
            // 
            // txtCallbackAddress
            // 
            this.txtCallbackAddress.Location = new System.Drawing.Point(858, 85);
            this.txtCallbackAddress.Name = "txtCallbackAddress";
            this.txtCallbackAddress.Size = new System.Drawing.Size(100, 20);
            this.txtCallbackAddress.TabIndex = 33;
            this.txtCallbackAddress.Text = "192.168.19.10";
            this.txtCallbackAddress.TextChanged += new System.EventHandler(this.txtCallbackAddress_TextChanged);
            // 
            // txtAccessPointDescription
            // 
            this.txtAccessPointDescription.Enabled = false;
            this.txtAccessPointDescription.Location = new System.Drawing.Point(653, 33);
            this.txtAccessPointDescription.Name = "txtAccessPointDescription";
            this.txtAccessPointDescription.Size = new System.Drawing.Size(178, 20);
            this.txtAccessPointDescription.TabIndex = 32;
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(650, 17);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(82, 13);
            this.label32.TabIndex = 31;
            this.label32.Text = "Add Description";
            // 
            // btnAddReaderDescription
            // 
            this.btnAddReaderDescription.Enabled = false;
            this.btnAddReaderDescription.Location = new System.Drawing.Point(653, 59);
            this.btnAddReaderDescription.Name = "btnAddReaderDescription";
            this.btnAddReaderDescription.Size = new System.Drawing.Size(178, 23);
            this.btnAddReaderDescription.TabIndex = 30;
            this.btnAddReaderDescription.Text = "addReaderDescription";
            this.btnAddReaderDescription.UseVisualStyleBackColor = true;
            this.btnAddReaderDescription.Click += new System.EventHandler(this.btnAddReaderDescription_Click);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(855, 16);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(81, 13);
            this.label15.TabIndex = 29;
            this.label15.Text = "DSR IPAddress";
            // 
            // txtDSRIpAddress
            // 
            this.txtDSRIpAddress.Location = new System.Drawing.Point(858, 33);
            this.txtDSRIpAddress.Name = "txtDSRIpAddress";
            this.txtDSRIpAddress.Size = new System.Drawing.Size(100, 20);
            this.txtDSRIpAddress.TabIndex = 28;
            this.txtDSRIpAddress.Text = "192.168.24.12";
            this.txtDSRIpAddress.TextChanged += new System.EventHandler(this.txtDSRIpAddress_TextChanged);
            // 
            // txtAddAccessPointSerialNumber
            // 
            this.txtAddAccessPointSerialNumber.Enabled = false;
            this.txtAddAccessPointSerialNumber.Location = new System.Drawing.Point(467, 189);
            this.txtAddAccessPointSerialNumber.Name = "txtAddAccessPointSerialNumber";
            this.txtAddAccessPointSerialNumber.Size = new System.Drawing.Size(178, 20);
            this.txtAddAccessPointSerialNumber.TabIndex = 27;
            this.txtAddAccessPointSerialNumber.TextChanged += new System.EventHandler(this.txtAddAccessPointSerialNumber_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(464, 175);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(160, 13);
            this.label1.TabIndex = 26;
            this.label1.Text = "Add Access Point Serial Number";
            // 
            // btnEnableAccessPoint
            // 
            this.btnEnableAccessPoint.Enabled = false;
            this.btnEnableAccessPoint.Location = new System.Drawing.Point(467, 75);
            this.btnEnableAccessPoint.Name = "btnEnableAccessPoint";
            this.btnEnableAccessPoint.Size = new System.Drawing.Size(178, 23);
            this.btnEnableAccessPoint.TabIndex = 25;
            this.btnEnableAccessPoint.Text = "enableAccessPoint";
            this.btnEnableAccessPoint.UseVisualStyleBackColor = true;
            this.btnEnableAccessPoint.Click += new System.EventHandler(this.btnEnableAccessPoint_Click);
            // 
            // btnDisableAccessPoint
            // 
            this.btnDisableAccessPoint.Enabled = false;
            this.btnDisableAccessPoint.Location = new System.Drawing.Point(237, 75);
            this.btnDisableAccessPoint.Name = "btnDisableAccessPoint";
            this.btnDisableAccessPoint.Size = new System.Drawing.Size(178, 23);
            this.btnDisableAccessPoint.TabIndex = 24;
            this.btnDisableAccessPoint.Text = "disableAccessPoint";
            this.btnDisableAccessPoint.UseVisualStyleBackColor = true;
            this.btnDisableAccessPoint.Click += new System.EventHandler(this.btnDisableAccessPoint_Click);
            // 
            // btnAddAndConfirmAccessPoint
            // 
            this.btnAddAndConfirmAccessPoint.Enabled = false;
            this.btnAddAndConfirmAccessPoint.Location = new System.Drawing.Point(651, 189);
            this.btnAddAndConfirmAccessPoint.Name = "btnAddAndConfirmAccessPoint";
            this.btnAddAndConfirmAccessPoint.Size = new System.Drawing.Size(178, 23);
            this.btnAddAndConfirmAccessPoint.TabIndex = 13;
            this.btnAddAndConfirmAccessPoint.Text = "addAndConfirmAccessPoint";
            this.btnAddAndConfirmAccessPoint.UseVisualStyleBackColor = true;
            this.btnAddAndConfirmAccessPoint.Click += new System.EventHandler(this.btnAddAndConfirmAccessPoint_Click);
            // 
            // btnReplaceAccessPoint
            // 
            this.btnReplaceAccessPoint.Enabled = false;
            this.btnReplaceAccessPoint.Location = new System.Drawing.Point(237, 104);
            this.btnReplaceAccessPoint.Name = "btnReplaceAccessPoint";
            this.btnReplaceAccessPoint.Size = new System.Drawing.Size(178, 23);
            this.btnReplaceAccessPoint.TabIndex = 23;
            this.btnReplaceAccessPoint.Text = "replaceAccessPoint";
            this.btnReplaceAccessPoint.UseVisualStyleBackColor = true;
            this.btnReplaceAccessPoint.Click += new System.EventHandler(this.btnReplaceAccessPoint_Click);
            // 
            // btnClearAccessPoint
            // 
            this.btnClearAccessPoint.Enabled = false;
            this.btnClearAccessPoint.Location = new System.Drawing.Point(466, 133);
            this.btnClearAccessPoint.Name = "btnClearAccessPoint";
            this.btnClearAccessPoint.Size = new System.Drawing.Size(178, 23);
            this.btnClearAccessPoint.TabIndex = 22;
            this.btnClearAccessPoint.Text = "clearAccessPoint";
            this.btnClearAccessPoint.UseVisualStyleBackColor = true;
            this.btnClearAccessPoint.Click += new System.EventHandler(this.btnClearAccessPoint_Click);
            // 
            // btnRemoveAccessPoint
            // 
            this.btnRemoveAccessPoint.Enabled = false;
            this.btnRemoveAccessPoint.Location = new System.Drawing.Point(237, 133);
            this.btnRemoveAccessPoint.Name = "btnRemoveAccessPoint";
            this.btnRemoveAccessPoint.Size = new System.Drawing.Size(178, 23);
            this.btnRemoveAccessPoint.TabIndex = 21;
            this.btnRemoveAccessPoint.Text = "removeAccessPoint";
            this.btnRemoveAccessPoint.UseVisualStyleBackColor = true;
            this.btnRemoveAccessPoint.Click += new System.EventHandler(this.btnRemoveAccessPoint_Click);
            // 
            // btnSetAccessPointEndpointParams
            // 
            this.btnSetAccessPointEndpointParams.Enabled = false;
            this.btnSetAccessPointEndpointParams.Location = new System.Drawing.Point(7, 421);
            this.btnSetAccessPointEndpointParams.Name = "btnSetAccessPointEndpointParams";
            this.btnSetAccessPointEndpointParams.Size = new System.Drawing.Size(224, 23);
            this.btnSetAccessPointEndpointParams.TabIndex = 20;
            this.btnSetAccessPointEndpointParams.Text = "setAccessPointEndpointParams";
            this.btnSetAccessPointEndpointParams.UseVisualStyleBackColor = true;
            this.btnSetAccessPointEndpointParams.Click += new System.EventHandler(this.btnSetAccessPointEndpointParams_Click);
            // 
            // btnGetStatus
            // 
            this.btnGetStatus.Location = new System.Drawing.Point(7, 77);
            this.btnGetStatus.Name = "btnGetStatus";
            this.btnGetStatus.Size = new System.Drawing.Size(224, 23);
            this.btnGetStatus.TabIndex = 19;
            this.btnGetStatus.Text = "getStatus";
            this.btnGetStatus.UseVisualStyleBackColor = true;
            this.btnGetStatus.Click += new System.EventHandler(this.btnGetStatus_Click);
            // 
            // btnGetVersionInfo
            // 
            this.btnGetVersionInfo.Location = new System.Drawing.Point(7, 48);
            this.btnGetVersionInfo.Name = "btnGetVersionInfo";
            this.btnGetVersionInfo.Size = new System.Drawing.Size(224, 23);
            this.btnGetVersionInfo.TabIndex = 18;
            this.btnGetVersionInfo.Text = "getVersionInfo";
            this.btnGetVersionInfo.UseVisualStyleBackColor = true;
            this.btnGetVersionInfo.Click += new System.EventHandler(this.btnGetVersionInfo_Click);
            // 
            // btnGetSupportedCredentialFormats
            // 
            this.btnGetSupportedCredentialFormats.Enabled = false;
            this.btnGetSupportedCredentialFormats.Location = new System.Drawing.Point(7, 276);
            this.btnGetSupportedCredentialFormats.Name = "btnGetSupportedCredentialFormats";
            this.btnGetSupportedCredentialFormats.Size = new System.Drawing.Size(224, 23);
            this.btnGetSupportedCredentialFormats.TabIndex = 17;
            this.btnGetSupportedCredentialFormats.Text = "getSupportedCredentialFormats";
            this.btnGetSupportedCredentialFormats.UseVisualStyleBackColor = true;
            this.btnGetSupportedCredentialFormats.Click += new System.EventHandler(this.btnGetSupportedCredentialFormats_Click);
            // 
            // btnUnregisterCallback
            // 
            this.btnUnregisterCallback.Location = new System.Drawing.Point(7, 392);
            this.btnUnregisterCallback.Name = "btnUnregisterCallback";
            this.btnUnregisterCallback.Size = new System.Drawing.Size(224, 23);
            this.btnUnregisterCallback.TabIndex = 16;
            this.btnUnregisterCallback.Text = "unRegisterCallback";
            this.btnUnregisterCallback.UseVisualStyleBackColor = true;
            this.btnUnregisterCallback.Click += new System.EventHandler(this.btnUnregisterCallback_Click);
            // 
            // btnListCallbackEndpoints
            // 
            this.btnListCallbackEndpoints.Location = new System.Drawing.Point(7, 363);
            this.btnListCallbackEndpoints.Name = "btnListCallbackEndpoints";
            this.btnListCallbackEndpoints.Size = new System.Drawing.Size(224, 23);
            this.btnListCallbackEndpoints.TabIndex = 15;
            this.btnListCallbackEndpoints.Text = "listCallbackEndpoints";
            this.btnListCallbackEndpoints.UseVisualStyleBackColor = true;
            this.btnListCallbackEndpoints.Click += new System.EventHandler(this.btnListCallbackEndpoints_Click);
            // 
            // btnRegisterCallback
            // 
            this.btnRegisterCallback.Location = new System.Drawing.Point(7, 334);
            this.btnRegisterCallback.Name = "btnRegisterCallback";
            this.btnRegisterCallback.Size = new System.Drawing.Size(224, 23);
            this.btnRegisterCallback.TabIndex = 14;
            this.btnRegisterCallback.Text = "registerCallback";
            this.btnRegisterCallback.UseVisualStyleBackColor = true;
            this.btnRegisterCallback.Click += new System.EventHandler(this.btnRegisterCallback_Click);
            // 
            // btnConfirmAccessPoint
            // 
            this.btnConfirmAccessPoint.Enabled = false;
            this.btnConfirmAccessPoint.Location = new System.Drawing.Point(467, 104);
            this.btnConfirmAccessPoint.Name = "btnConfirmAccessPoint";
            this.btnConfirmAccessPoint.Size = new System.Drawing.Size(178, 23);
            this.btnConfirmAccessPoint.TabIndex = 12;
            this.btnConfirmAccessPoint.Text = "confirmAccessPoint";
            this.btnConfirmAccessPoint.UseVisualStyleBackColor = true;
            this.btnConfirmAccessPoint.Click += new System.EventHandler(this.btnConfirmAccessPoint_Click);
            // 
            // btnVerifyAccessPointOnline
            // 
            this.btnVerifyAccessPointOnline.Enabled = false;
            this.btnVerifyAccessPointOnline.Location = new System.Drawing.Point(467, 46);
            this.btnVerifyAccessPointOnline.Name = "btnVerifyAccessPointOnline";
            this.btnVerifyAccessPointOnline.Size = new System.Drawing.Size(178, 23);
            this.btnVerifyAccessPointOnline.TabIndex = 11;
            this.btnVerifyAccessPointOnline.Text = "verifyAccessPointOnline";
            this.btnVerifyAccessPointOnline.UseVisualStyleBackColor = true;
            this.btnVerifyAccessPointOnline.Click += new System.EventHandler(this.btnVerifyAccessPointOnline_Click);
            // 
            // btnFindAccessPointBySerialNumber
            // 
            this.btnFindAccessPointBySerialNumber.Location = new System.Drawing.Point(6, 305);
            this.btnFindAccessPointBySerialNumber.Name = "btnFindAccessPointBySerialNumber";
            this.btnFindAccessPointBySerialNumber.Size = new System.Drawing.Size(224, 23);
            this.btnFindAccessPointBySerialNumber.TabIndex = 10;
            this.btnFindAccessPointBySerialNumber.Text = "findAccessPointBySerialNumber";
            this.btnFindAccessPointBySerialNumber.UseVisualStyleBackColor = true;
            this.btnFindAccessPointBySerialNumber.Click += new System.EventHandler(this.btnFindAccessPointBySerialNumber_Click);
            // 
            // btnGetAccessPointStatus
            // 
            this.btnGetAccessPointStatus.Enabled = false;
            this.btnGetAccessPointStatus.Location = new System.Drawing.Point(237, 46);
            this.btnGetAccessPointStatus.Name = "btnGetAccessPointStatus";
            this.btnGetAccessPointStatus.Size = new System.Drawing.Size(178, 23);
            this.btnGetAccessPointStatus.TabIndex = 9;
            this.btnGetAccessPointStatus.Text = "getAccessPointStatus";
            this.btnGetAccessPointStatus.UseVisualStyleBackColor = true;
            this.btnGetAccessPointStatus.Click += new System.EventHandler(this.btnGetAccessPointStatus_Click);
            // 
            // cbAccessPointsOnline
            // 
            this.cbAccessPointsOnline.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAccessPointsOnline.FormattingEnabled = true;
            this.cbAccessPointsOnline.Location = new System.Drawing.Point(237, 249);
            this.cbAccessPointsOnline.Name = "cbAccessPointsOnline";
            this.cbAccessPointsOnline.Size = new System.Drawing.Size(407, 21);
            this.cbAccessPointsOnline.TabIndex = 8;
            // 
            // btnListAccessPointsOnline
            // 
            this.btnListAccessPointsOnline.Enabled = false;
            this.btnListAccessPointsOnline.Location = new System.Drawing.Point(7, 249);
            this.btnListAccessPointsOnline.Name = "btnListAccessPointsOnline";
            this.btnListAccessPointsOnline.Size = new System.Drawing.Size(224, 23);
            this.btnListAccessPointsOnline.TabIndex = 7;
            this.btnListAccessPointsOnline.Text = "listAccessPointsOnline";
            this.btnListAccessPointsOnline.UseVisualStyleBackColor = true;
            this.btnListAccessPointsOnline.Click += new System.EventHandler(this.btnListAccessPointsOnline_Click);
            // 
            // cbAccessPointsByType
            // 
            this.cbAccessPointsByType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAccessPointsByType.FormattingEnabled = true;
            this.cbAccessPointsByType.Location = new System.Drawing.Point(237, 222);
            this.cbAccessPointsByType.Name = "cbAccessPointsByType";
            this.cbAccessPointsByType.Size = new System.Drawing.Size(407, 21);
            this.cbAccessPointsByType.TabIndex = 6;
            this.cbAccessPointsByType.SelectedIndexChanged += new System.EventHandler(this.cbAccessPointsByType_SelectedIndexChanged);
            // 
            // cbAccessPointTypes
            // 
            this.cbAccessPointTypes.DisplayMember = "displayName";
            this.cbAccessPointTypes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAccessPointTypes.FormattingEnabled = true;
            this.cbAccessPointTypes.Location = new System.Drawing.Point(237, 191);
            this.cbAccessPointTypes.Name = "cbAccessPointTypes";
            this.cbAccessPointTypes.Size = new System.Drawing.Size(200, 21);
            this.cbAccessPointTypes.TabIndex = 5;
            this.cbAccessPointTypes.SelectedIndexChanged += new System.EventHandler(this.cbAccessPointTypes_SelectedIndexChanged);
            // 
            // btnGetAccessPointTypes
            // 
            this.btnGetAccessPointTypes.Location = new System.Drawing.Point(7, 191);
            this.btnGetAccessPointTypes.Name = "btnGetAccessPointTypes";
            this.btnGetAccessPointTypes.Size = new System.Drawing.Size(224, 23);
            this.btnGetAccessPointTypes.TabIndex = 3;
            this.btnGetAccessPointTypes.Text = "getAccessPointTypes";
            this.btnGetAccessPointTypes.UseVisualStyleBackColor = true;
            this.btnGetAccessPointTypes.Click += new System.EventHandler(this.btnGetAccessPointTypes_Click);
            // 
            // cbAllAccessPoints
            // 
            this.cbAllAccessPoints.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAllAccessPoints.FormattingEnabled = true;
            this.cbAllAccessPoints.Location = new System.Drawing.Point(237, 19);
            this.cbAllAccessPoints.Name = "cbAllAccessPoints";
            this.cbAllAccessPoints.Size = new System.Drawing.Size(407, 21);
            this.cbAllAccessPoints.TabIndex = 4;
            this.cbAllAccessPoints.SelectedIndexChanged += new System.EventHandler(this.cbAllAccessPoints_SelectedIndexChanged);
            // 
            // btnListAllAccessPoints
            // 
            this.btnListAllAccessPoints.Location = new System.Drawing.Point(6, 19);
            this.btnListAllAccessPoints.Name = "btnListAllAccessPoints";
            this.btnListAllAccessPoints.Size = new System.Drawing.Size(225, 23);
            this.btnListAllAccessPoints.TabIndex = 2;
            this.btnListAllAccessPoints.Text = "listAllAccessPoints";
            this.btnListAllAccessPoints.UseVisualStyleBackColor = true;
            this.btnListAllAccessPoints.Click += new System.EventHandler(this.btnListAllAccessPoints_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.tabControl);
            this.groupBox2.Controls.Add(this.btnClearAll);
            this.groupBox2.Controls.Add(this.btnDeleteAllOrphanEntities);
            this.groupBox2.Location = new System.Drawing.Point(6, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1042, 433);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Access Control Service";
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPageUsers);
            this.tabControl.Controls.Add(this.tabPageDayPeriods);
            this.tabControl.Controls.Add(this.tabPageDayExceptions);
            this.tabControl.Controls.Add(this.tabPageSchedules);
            this.tabControl.Controls.Add(this.tabPageAuthorizations);
            this.tabControl.Controls.Add(this.tabPageAccessPointSpecificOperations);
            this.tabControl.Controls.Add(this.tabPageAccessPointModes);
            this.tabControl.Location = new System.Drawing.Point(10, 19);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1029, 379);
            this.tabControl.TabIndex = 16;
            // 
            // tabPageUsers
            // 
            this.tabPageUsers.Controls.Add(this.btnFindUserByCardNumbers);
            this.tabPageUsers.Controls.Add(this.lblUserCount);
            this.tabPageUsers.Controls.Add(this.txtCredentialPINStringValue);
            this.tabPageUsers.Controls.Add(this.label42);
            this.tabPageUsers.Controls.Add(this.label27);
            this.tabPageUsers.Controls.Add(this.cbUserAuthorizationSchedule);
            this.tabPageUsers.Controls.Add(this.label8);
            this.tabPageUsers.Controls.Add(this.cbUserAuthorizationType);
            this.tabPageUsers.Controls.Add(this.label26);
            this.tabPageUsers.Controls.Add(this.clbUserAuthorizeAccessPoints);
            this.tabPageUsers.Controls.Add(this.cbUserIds);
            this.tabPageUsers.Controls.Add(this.txtCredentialIntegerValue);
            this.tabPageUsers.Controls.Add(this.label12);
            this.tabPageUsers.Controls.Add(this.txtCredentialFacilityCode);
            this.tabPageUsers.Controls.Add(this.label11);
            this.tabPageUsers.Controls.Add(this.txtCredentialStringValue);
            this.tabPageUsers.Controls.Add(this.label10);
            this.tabPageUsers.Controls.Add(this.label9);
            this.tabPageUsers.Controls.Add(this.cbCredentialFormats);
            this.tabPageUsers.Controls.Add(this.btnRemoveUserCascading);
            this.tabPageUsers.Controls.Add(this.btnModifyUser);
            this.tabPageUsers.Controls.Add(this.btnRemoveUser);
            this.tabPageUsers.Controls.Add(this.btnGetUserIds);
            this.tabPageUsers.Controls.Add(this.chkUserSuspended);
            this.tabPageUsers.Controls.Add(this.chkUserExtended);
            this.tabPageUsers.Controls.Add(this.label6);
            this.tabPageUsers.Controls.Add(this.label7);
            this.tabPageUsers.Controls.Add(this.dtpUserValidUntil);
            this.tabPageUsers.Controls.Add(this.dtpUserValidFrom);
            this.tabPageUsers.Controls.Add(this.btnAddUser);
            this.tabPageUsers.Location = new System.Drawing.Point(4, 22);
            this.tabPageUsers.Name = "tabPageUsers";
            this.tabPageUsers.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageUsers.Size = new System.Drawing.Size(1021, 353);
            this.tabPageUsers.TabIndex = 0;
            this.tabPageUsers.Text = "Users";
            this.tabPageUsers.UseVisualStyleBackColor = true;
            // 
            // lblUserCount
            // 
            this.lblUserCount.AutoSize = true;
            this.lblUserCount.Location = new System.Drawing.Point(279, 39);
            this.lblUserCount.Name = "lblUserCount";
            this.lblUserCount.Size = new System.Drawing.Size(0, 13);
            this.lblUserCount.TabIndex = 66;
            // 
            // txtCredentialPINStringValue
            // 
            this.txtCredentialPINStringValue.Location = new System.Drawing.Point(12, 245);
            this.txtCredentialPINStringValue.Name = "txtCredentialPINStringValue";
            this.txtCredentialPINStringValue.Size = new System.Drawing.Size(72, 20);
            this.txtCredentialPINStringValue.TabIndex = 65;
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.Location = new System.Drawing.Point(9, 228);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(58, 13);
            this.label42.TabIndex = 64;
            this.label42.Text = "PIN Value:";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(713, 9);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(52, 13);
            this.label27.TabIndex = 63;
            this.label27.Text = "Schedule";
            // 
            // cbUserAuthorizationSchedule
            // 
            this.cbUserAuthorizationSchedule.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbUserAuthorizationSchedule.FormattingEnabled = true;
            this.cbUserAuthorizationSchedule.Location = new System.Drawing.Point(716, 25);
            this.cbUserAuthorizationSchedule.Name = "cbUserAuthorizationSchedule";
            this.cbUserAuthorizationSchedule.Size = new System.Drawing.Size(188, 21);
            this.cbUserAuthorizationSchedule.TabIndex = 62;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(519, 9);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(95, 13);
            this.label8.TabIndex = 61;
            this.label8.Text = "Authorization Type";
            // 
            // cbUserAuthorizationType
            // 
            this.cbUserAuthorizationType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbUserAuthorizationType.FormattingEnabled = true;
            this.cbUserAuthorizationType.Location = new System.Drawing.Point(519, 25);
            this.cbUserAuthorizationType.Name = "cbUserAuthorizationType";
            this.cbUserAuthorizationType.Size = new System.Drawing.Size(188, 21);
            this.cbUserAuthorizationType.TabIndex = 60;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(519, 59);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(127, 13);
            this.label26.TabIndex = 59;
            this.label26.Text = "Authorized Access Points";
            // 
            // clbUserAuthorizeAccessPoints
            // 
            this.clbUserAuthorizeAccessPoints.FormattingEnabled = true;
            this.clbUserAuthorizeAccessPoints.Location = new System.Drawing.Point(519, 75);
            this.clbUserAuthorizeAccessPoints.Name = "clbUserAuthorizeAccessPoints";
            this.clbUserAuthorizeAccessPoints.Size = new System.Drawing.Size(373, 244);
            this.clbUserAuthorizeAccessPoints.TabIndex = 58;
            // 
            // cbUserIds
            // 
            this.cbUserIds.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbUserIds.FormattingEnabled = true;
            this.cbUserIds.Location = new System.Drawing.Point(99, 6);
            this.cbUserIds.Name = "cbUserIds";
            this.cbUserIds.Size = new System.Drawing.Size(280, 21);
            this.cbUserIds.Sorted = true;
            this.cbUserIds.TabIndex = 41;
            this.cbUserIds.SelectedIndexChanged += new System.EventHandler(this.cbUserIds_SelectedIndexChanged);
            // 
            // txtCredentialIntegerValue
            // 
            this.txtCredentialIntegerValue.Location = new System.Drawing.Point(99, 180);
            this.txtCredentialIntegerValue.Name = "txtCredentialIntegerValue";
            this.txtCredentialIntegerValue.Size = new System.Drawing.Size(103, 20);
            this.txtCredentialIntegerValue.TabIndex = 40;
            this.txtCredentialIntegerValue.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCredentialIntegerValue_KeyPress);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(96, 163);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(71, 13);
            this.label12.TabIndex = 39;
            this.label12.Text = "Integer Code:";
            // 
            // txtCredentialFacilityCode
            // 
            this.txtCredentialFacilityCode.Location = new System.Drawing.Point(9, 180);
            this.txtCredentialFacilityCode.Name = "txtCredentialFacilityCode";
            this.txtCredentialFacilityCode.Size = new System.Drawing.Size(72, 20);
            this.txtCredentialFacilityCode.TabIndex = 38;
            this.txtCredentialFacilityCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCredentialFacilityCode_KeyPress);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 163);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(70, 13);
            this.label11.TabIndex = 37;
            this.label11.Text = "Facility Code:";
            // 
            // txtCredentialStringValue
            // 
            this.txtCredentialStringValue.Location = new System.Drawing.Point(182, 131);
            this.txtCredentialStringValue.Name = "txtCredentialStringValue";
            this.txtCredentialStringValue.Size = new System.Drawing.Size(155, 20);
            this.txtCredentialStringValue.TabIndex = 36;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(179, 114);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(67, 13);
            this.label10.TabIndex = 35;
            this.label10.Text = "String Value:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 114);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(92, 13);
            this.label9.TabIndex = 34;
            this.label9.Text = "Credential Format:";
            // 
            // cbCredentialFormats
            // 
            this.cbCredentialFormats.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCredentialFormats.FormattingEnabled = true;
            this.cbCredentialFormats.Location = new System.Drawing.Point(9, 130);
            this.cbCredentialFormats.Name = "cbCredentialFormats";
            this.cbCredentialFormats.Size = new System.Drawing.Size(157, 21);
            this.cbCredentialFormats.TabIndex = 33;
            // 
            // btnRemoveUserCascading
            // 
            this.btnRemoveUserCascading.Location = new System.Drawing.Point(332, 90);
            this.btnRemoveUserCascading.Name = "btnRemoveUserCascading";
            this.btnRemoveUserCascading.Size = new System.Drawing.Size(137, 23);
            this.btnRemoveUserCascading.TabIndex = 32;
            this.btnRemoveUserCascading.Text = "removeUserCascading";
            this.btnRemoveUserCascading.UseVisualStyleBackColor = true;
            this.btnRemoveUserCascading.Click += new System.EventHandler(this.btnRemoveUserCascading_Click);
            // 
            // btnModifyUser
            // 
            this.btnModifyUser.Location = new System.Drawing.Point(394, 63);
            this.btnModifyUser.Name = "btnModifyUser";
            this.btnModifyUser.Size = new System.Drawing.Size(75, 23);
            this.btnModifyUser.TabIndex = 31;
            this.btnModifyUser.Text = "modifyUser";
            this.btnModifyUser.UseVisualStyleBackColor = true;
            this.btnModifyUser.Click += new System.EventHandler(this.btnModifyUser_Click);
            // 
            // btnRemoveUser
            // 
            this.btnRemoveUser.Location = new System.Drawing.Point(394, 6);
            this.btnRemoveUser.Name = "btnRemoveUser";
            this.btnRemoveUser.Size = new System.Drawing.Size(75, 23);
            this.btnRemoveUser.TabIndex = 27;
            this.btnRemoveUser.Text = "removeUser";
            this.btnRemoveUser.UseVisualStyleBackColor = true;
            this.btnRemoveUser.Click += new System.EventHandler(this.btnRemoveUser_Click);
            // 
            // btnGetUserIds
            // 
            this.btnGetUserIds.Location = new System.Drawing.Point(9, 6);
            this.btnGetUserIds.Name = "btnGetUserIds";
            this.btnGetUserIds.Size = new System.Drawing.Size(75, 23);
            this.btnGetUserIds.TabIndex = 26;
            this.btnGetUserIds.Text = "getUserIds";
            this.btnGetUserIds.UseVisualStyleBackColor = true;
            this.btnGetUserIds.Click += new System.EventHandler(this.btnGetUserIds_Click);
            // 
            // chkUserSuspended
            // 
            this.chkUserSuspended.AutoSize = true;
            this.chkUserSuspended.Location = new System.Drawing.Point(111, 83);
            this.chkUserSuspended.Name = "chkUserSuspended";
            this.chkUserSuspended.Size = new System.Drawing.Size(91, 17);
            this.chkUserSuspended.TabIndex = 25;
            this.chkUserSuspended.Text = "Is Suspended";
            this.chkUserSuspended.UseVisualStyleBackColor = true;
            // 
            // chkUserExtended
            // 
            this.chkUserExtended.AutoSize = true;
            this.chkUserExtended.Location = new System.Drawing.Point(9, 83);
            this.chkUserExtended.Name = "chkUserExtended";
            this.chkUserExtended.Size = new System.Drawing.Size(96, 17);
            this.chkUserExtended.TabIndex = 24;
            this.chkUserExtended.Text = "Extended User";
            this.chkUserExtended.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(174, 40);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(97, 13);
            this.label6.TabIndex = 23;
            this.label6.Text = "Ending Date/Time:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 40);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(100, 13);
            this.label7.TabIndex = 20;
            this.label7.Text = "Starting Date/Time:";
            // 
            // dtpUserValidUntil
            // 
            this.dtpUserValidUntil.CustomFormat = "M-d-yyyy hh:mm:ss tt";
            this.dtpUserValidUntil.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpUserValidUntil.Location = new System.Drawing.Point(177, 56);
            this.dtpUserValidUntil.Name = "dtpUserValidUntil";
            this.dtpUserValidUntil.Size = new System.Drawing.Size(160, 20);
            this.dtpUserValidUntil.TabIndex = 22;
            // 
            // dtpUserValidFrom
            // 
            this.dtpUserValidFrom.CustomFormat = "M-d-yyyy hh:mm:ss tt";
            this.dtpUserValidFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpUserValidFrom.Location = new System.Drawing.Point(9, 56);
            this.dtpUserValidFrom.Name = "dtpUserValidFrom";
            this.dtpUserValidFrom.Size = new System.Drawing.Size(157, 20);
            this.dtpUserValidFrom.TabIndex = 21;
            this.dtpUserValidFrom.Value = new System.DateTime(2015, 10, 22, 2, 11, 0, 0);
            // 
            // btnAddUser
            // 
            this.btnAddUser.Location = new System.Drawing.Point(394, 34);
            this.btnAddUser.Name = "btnAddUser";
            this.btnAddUser.Size = new System.Drawing.Size(75, 23);
            this.btnAddUser.TabIndex = 0;
            this.btnAddUser.Text = "addUser";
            this.btnAddUser.UseVisualStyleBackColor = true;
            this.btnAddUser.Click += new System.EventHandler(this.btnAddUser_Click);
            // 
            // tabPageDayPeriods
            // 
            this.tabPageDayPeriods.Controls.Add(this.btnDayPeriodAddTimePeriod);
            this.tabPageDayPeriods.Controls.Add(this.clbDayPeriodTimePeriods);
            this.tabPageDayPeriods.Controls.Add(this.btnModifyDayPeriod);
            this.tabPageDayPeriods.Controls.Add(this.btnRemoveDayPeriod);
            this.tabPageDayPeriods.Controls.Add(this.label14);
            this.tabPageDayPeriods.Controls.Add(this.label13);
            this.tabPageDayPeriods.Controls.Add(this.dayPeriodEndTime);
            this.tabPageDayPeriods.Controls.Add(this.dayPeriodStartTime);
            this.tabPageDayPeriods.Controls.Add(this.WeekDayCheckBoxList);
            this.tabPageDayPeriods.Controls.Add(this.cbDayPeriodIdList);
            this.tabPageDayPeriods.Controls.Add(this.btnAddDayPeriod);
            this.tabPageDayPeriods.Controls.Add(this.btnGetDayPeriodIds);
            this.tabPageDayPeriods.Location = new System.Drawing.Point(4, 22);
            this.tabPageDayPeriods.Name = "tabPageDayPeriods";
            this.tabPageDayPeriods.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageDayPeriods.Size = new System.Drawing.Size(1021, 353);
            this.tabPageDayPeriods.TabIndex = 1;
            this.tabPageDayPeriods.Text = "DayPeriods";
            this.tabPageDayPeriods.UseVisualStyleBackColor = true;
            // 
            // btnDayPeriodAddTimePeriod
            // 
            this.btnDayPeriodAddTimePeriod.Location = new System.Drawing.Point(160, 98);
            this.btnDayPeriodAddTimePeriod.Name = "btnDayPeriodAddTimePeriod";
            this.btnDayPeriodAddTimePeriod.Size = new System.Drawing.Size(114, 23);
            this.btnDayPeriodAddTimePeriod.TabIndex = 44;
            this.btnDayPeriodAddTimePeriod.Text = "Add Time Period ";
            this.btnDayPeriodAddTimePeriod.UseVisualStyleBackColor = true;
            this.btnDayPeriodAddTimePeriod.Click += new System.EventHandler(this.btnDayPeriodAddTimePeriod_Click);
            // 
            // clbDayPeriodTimePeriods
            // 
            this.clbDayPeriodTimePeriods.FormattingEnabled = true;
            this.clbDayPeriodTimePeriods.Location = new System.Drawing.Point(160, 129);
            this.clbDayPeriodTimePeriods.Name = "clbDayPeriodTimePeriods";
            this.clbDayPeriodTimePeriods.Size = new System.Drawing.Size(198, 169);
            this.clbDayPeriodTimePeriods.TabIndex = 43;
            // 
            // btnModifyDayPeriod
            // 
            this.btnModifyDayPeriod.Location = new System.Drawing.Point(374, 68);
            this.btnModifyDayPeriod.Name = "btnModifyDayPeriod";
            this.btnModifyDayPeriod.Size = new System.Drawing.Size(107, 23);
            this.btnModifyDayPeriod.TabIndex = 27;
            this.btnModifyDayPeriod.Text = "modifyDayPeriod";
            this.btnModifyDayPeriod.UseVisualStyleBackColor = true;
            this.btnModifyDayPeriod.Click += new System.EventHandler(this.btnModifyDayPeriod_Click);
            // 
            // btnRemoveDayPeriod
            // 
            this.btnRemoveDayPeriod.Location = new System.Drawing.Point(374, 8);
            this.btnRemoveDayPeriod.Name = "btnRemoveDayPeriod";
            this.btnRemoveDayPeriod.Size = new System.Drawing.Size(107, 23);
            this.btnRemoveDayPeriod.TabIndex = 26;
            this.btnRemoveDayPeriod.Text = "removeDayPeriod";
            this.btnRemoveDayPeriod.UseVisualStyleBackColor = true;
            this.btnRemoveDayPeriod.Click += new System.EventHandler(this.btnRemoveDayPeriod_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(262, 44);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(55, 13);
            this.label14.TabIndex = 25;
            this.label14.Text = "End Time:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(152, 44);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(58, 13);
            this.label13.TabIndex = 21;
            this.label13.Text = "Start Time:";
            // 
            // dayPeriodEndTime
            // 
            this.dayPeriodEndTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dayPeriodEndTime.Location = new System.Drawing.Point(265, 60);
            this.dayPeriodEndTime.Name = "dayPeriodEndTime";
            this.dayPeriodEndTime.ShowUpDown = true;
            this.dayPeriodEndTime.Size = new System.Drawing.Size(93, 20);
            this.dayPeriodEndTime.TabIndex = 24;
            this.dayPeriodEndTime.Value = new System.DateTime(2016, 7, 1, 23, 59, 0, 0);
            // 
            // dayPeriodStartTime
            // 
            this.dayPeriodStartTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dayPeriodStartTime.Location = new System.Drawing.Point(152, 60);
            this.dayPeriodStartTime.Name = "dayPeriodStartTime";
            this.dayPeriodStartTime.ShowUpDown = true;
            this.dayPeriodStartTime.Size = new System.Drawing.Size(93, 20);
            this.dayPeriodStartTime.TabIndex = 23;
            this.dayPeriodStartTime.Value = new System.DateTime(2016, 7, 1, 0, 0, 0, 0);
            // 
            // WeekDayCheckBoxList
            // 
            this.WeekDayCheckBoxList.FormattingEnabled = true;
            this.WeekDayCheckBoxList.Location = new System.Drawing.Point(6, 35);
            this.WeekDayCheckBoxList.Name = "WeekDayCheckBoxList";
            this.WeekDayCheckBoxList.Size = new System.Drawing.Size(140, 124);
            this.WeekDayCheckBoxList.TabIndex = 22;
            // 
            // cbDayPeriodIdList
            // 
            this.cbDayPeriodIdList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDayPeriodIdList.FormattingEnabled = true;
            this.cbDayPeriodIdList.Location = new System.Drawing.Point(119, 8);
            this.cbDayPeriodIdList.Name = "cbDayPeriodIdList";
            this.cbDayPeriodIdList.Size = new System.Drawing.Size(249, 21);
            this.cbDayPeriodIdList.TabIndex = 21;
            this.cbDayPeriodIdList.SelectedIndexChanged += new System.EventHandler(this.cbDayPeriodIdList_SelectedIndexChanged);
            // 
            // btnAddDayPeriod
            // 
            this.btnAddDayPeriod.Location = new System.Drawing.Point(374, 39);
            this.btnAddDayPeriod.Name = "btnAddDayPeriod";
            this.btnAddDayPeriod.Size = new System.Drawing.Size(107, 23);
            this.btnAddDayPeriod.TabIndex = 18;
            this.btnAddDayPeriod.Text = "addDayPeriod";
            this.btnAddDayPeriod.UseVisualStyleBackColor = true;
            this.btnAddDayPeriod.Click += new System.EventHandler(this.btnAddDayPeriod_Click);
            // 
            // btnGetDayPeriodIds
            // 
            this.btnGetDayPeriodIds.Location = new System.Drawing.Point(6, 6);
            this.btnGetDayPeriodIds.Name = "btnGetDayPeriodIds";
            this.btnGetDayPeriodIds.Size = new System.Drawing.Size(103, 23);
            this.btnGetDayPeriodIds.TabIndex = 17;
            this.btnGetDayPeriodIds.Text = "getDayPeriodIds";
            this.btnGetDayPeriodIds.UseVisualStyleBackColor = true;
            this.btnGetDayPeriodIds.Click += new System.EventHandler(this.btnGetDayPeriodIds_Click);
            // 
            // tabPageDayExceptions
            // 
            this.tabPageDayExceptions.Controls.Add(this.groupBox3);
            this.tabPageDayExceptions.Controls.Add(this.btnDayExceptionAddTimePeriod);
            this.tabPageDayExceptions.Controls.Add(this.clbDayExceptionTimePeriods);
            this.tabPageDayExceptions.Controls.Add(this.dtpDayExceptionEndTime);
            this.tabPageDayExceptions.Controls.Add(this.dtpDayExceptionStartTime);
            this.tabPageDayExceptions.Controls.Add(this.label17);
            this.tabPageDayExceptions.Controls.Add(this.label18);
            this.tabPageDayExceptions.Controls.Add(this.label16);
            this.tabPageDayExceptions.Controls.Add(this.dtpDayExceptionDate);
            this.tabPageDayExceptions.Controls.Add(this.btnModifyDayException);
            this.tabPageDayExceptions.Controls.Add(this.btnRemoveDayException);
            this.tabPageDayExceptions.Controls.Add(this.cbDayExceptionIdList);
            this.tabPageDayExceptions.Controls.Add(this.btnAddDayException);
            this.tabPageDayExceptions.Controls.Add(this.btnGetDayExceptionIds);
            this.tabPageDayExceptions.Location = new System.Drawing.Point(4, 22);
            this.tabPageDayExceptions.Name = "tabPageDayExceptions";
            this.tabPageDayExceptions.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageDayExceptions.Size = new System.Drawing.Size(1021, 353);
            this.tabPageDayExceptions.TabIndex = 4;
            this.tabPageDayExceptions.Text = "DayExceptions";
            this.tabPageDayExceptions.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnRemoveDayExceptionFromDayExceptionGroup);
            this.groupBox3.Controls.Add(this.btnAddDayExceptionToDayExceptionGroup);
            this.groupBox3.Controls.Add(this.label20);
            this.groupBox3.Controls.Add(this.btnModifyDayExceptionGroup);
            this.groupBox3.Controls.Add(this.clbDayExceptionGroupsDayExceptionIdList);
            this.groupBox3.Controls.Add(this.btnRemoveDayExceptionGroup);
            this.groupBox3.Controls.Add(this.btnGetDayExceptionGroupIds);
            this.groupBox3.Controls.Add(this.cbDayExceptionGroupIdList);
            this.groupBox3.Controls.Add(this.btnAddDayExceptionGroup);
            this.groupBox3.Controls.Add(this.ucDayExceptionViewControl);
            this.groupBox3.Location = new System.Drawing.Point(410, 8);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(596, 339);
            this.groupBox3.TabIndex = 43;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Day Exception Groups";
            // 
            // btnRemoveDayExceptionFromDayExceptionGroup
            // 
            this.btnRemoveDayExceptionFromDayExceptionGroup.Enabled = false;
            this.btnRemoveDayExceptionFromDayExceptionGroup.Location = new System.Drawing.Point(9, 311);
            this.btnRemoveDayExceptionFromDayExceptionGroup.Name = "btnRemoveDayExceptionFromDayExceptionGroup";
            this.btnRemoveDayExceptionFromDayExceptionGroup.Size = new System.Drawing.Size(263, 23);
            this.btnRemoveDayExceptionFromDayExceptionGroup.TabIndex = 52;
            this.btnRemoveDayExceptionFromDayExceptionGroup.Text = "removeDayExceptionFromDayExceptionGroup";
            this.btnRemoveDayExceptionFromDayExceptionGroup.UseVisualStyleBackColor = true;
            this.btnRemoveDayExceptionFromDayExceptionGroup.Click += new System.EventHandler(this.btnRemoveDayExceptionFromDayExceptionGroup_Click);
            // 
            // btnAddDayExceptionToDayExceptionGroup
            // 
            this.btnAddDayExceptionToDayExceptionGroup.Enabled = false;
            this.btnAddDayExceptionToDayExceptionGroup.Location = new System.Drawing.Point(9, 282);
            this.btnAddDayExceptionToDayExceptionGroup.Name = "btnAddDayExceptionToDayExceptionGroup";
            this.btnAddDayExceptionToDayExceptionGroup.Size = new System.Drawing.Size(263, 23);
            this.btnAddDayExceptionToDayExceptionGroup.TabIndex = 51;
            this.btnAddDayExceptionToDayExceptionGroup.Text = "addDayExceptionToDayExceptionGroup";
            this.btnAddDayExceptionToDayExceptionGroup.UseVisualStyleBackColor = true;
            this.btnAddDayExceptionToDayExceptionGroup.Click += new System.EventHandler(this.btnAddDayExceptionToDayExceptionGroup_Click);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(6, 51);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(81, 13);
            this.label20.TabIndex = 49;
            this.label20.Text = "Day Exceptions";
            // 
            // btnModifyDayExceptionGroup
            // 
            this.btnModifyDayExceptionGroup.Location = new System.Drawing.Point(439, 48);
            this.btnModifyDayExceptionGroup.Name = "btnModifyDayExceptionGroup";
            this.btnModifyDayExceptionGroup.Size = new System.Drawing.Size(151, 23);
            this.btnModifyDayExceptionGroup.TabIndex = 48;
            this.btnModifyDayExceptionGroup.Text = "modifyDayExceptionGroup";
            this.btnModifyDayExceptionGroup.UseVisualStyleBackColor = true;
            this.btnModifyDayExceptionGroup.Click += new System.EventHandler(this.btnModifyDayExceptionGroup_Click);
            // 
            // clbDayExceptionGroupsDayExceptionIdList
            // 
            this.clbDayExceptionGroupsDayExceptionIdList.FormattingEnabled = true;
            this.clbDayExceptionGroupsDayExceptionIdList.Location = new System.Drawing.Point(6, 66);
            this.clbDayExceptionGroupsDayExceptionIdList.Name = "clbDayExceptionGroupsDayExceptionIdList";
            this.clbDayExceptionGroupsDayExceptionIdList.Size = new System.Drawing.Size(266, 214);
            this.clbDayExceptionGroupsDayExceptionIdList.TabIndex = 42;
            this.clbDayExceptionGroupsDayExceptionIdList.SelectedIndexChanged += new System.EventHandler(this.clbDayExceptionGroupsDayExceptionIdList_SelectedIndexChanged);
            // 
            // btnRemoveDayExceptionGroup
            // 
            this.btnRemoveDayExceptionGroup.Location = new System.Drawing.Point(439, 77);
            this.btnRemoveDayExceptionGroup.Name = "btnRemoveDayExceptionGroup";
            this.btnRemoveDayExceptionGroup.Size = new System.Drawing.Size(151, 23);
            this.btnRemoveDayExceptionGroup.TabIndex = 47;
            this.btnRemoveDayExceptionGroup.Text = "removeDayExceptionGroup";
            this.btnRemoveDayExceptionGroup.UseVisualStyleBackColor = true;
            this.btnRemoveDayExceptionGroup.Click += new System.EventHandler(this.btnRemoveDayExceptionGroup_Click);
            // 
            // btnGetDayExceptionGroupIds
            // 
            this.btnGetDayExceptionGroupIds.Location = new System.Drawing.Point(6, 20);
            this.btnGetDayExceptionGroupIds.Name = "btnGetDayExceptionGroupIds";
            this.btnGetDayExceptionGroupIds.Size = new System.Drawing.Size(152, 25);
            this.btnGetDayExceptionGroupIds.TabIndex = 44;
            this.btnGetDayExceptionGroupIds.Text = "getDayExceptionGroupIds";
            this.btnGetDayExceptionGroupIds.UseVisualStyleBackColor = true;
            this.btnGetDayExceptionGroupIds.Click += new System.EventHandler(this.btnGetDayExceptionGroupIds_Click);
            // 
            // cbDayExceptionGroupIdList
            // 
            this.cbDayExceptionGroupIdList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDayExceptionGroupIdList.FormattingEnabled = true;
            this.cbDayExceptionGroupIdList.Location = new System.Drawing.Point(175, 20);
            this.cbDayExceptionGroupIdList.Name = "cbDayExceptionGroupIdList";
            this.cbDayExceptionGroupIdList.Size = new System.Drawing.Size(249, 21);
            this.cbDayExceptionGroupIdList.TabIndex = 46;
            this.cbDayExceptionGroupIdList.SelectedIndexChanged += new System.EventHandler(this.cbDayExceptionGroupIdList_SelectedIndexChanged);
            // 
            // btnAddDayExceptionGroup
            // 
            this.btnAddDayExceptionGroup.Location = new System.Drawing.Point(439, 19);
            this.btnAddDayExceptionGroup.Name = "btnAddDayExceptionGroup";
            this.btnAddDayExceptionGroup.Size = new System.Drawing.Size(151, 23);
            this.btnAddDayExceptionGroup.TabIndex = 45;
            this.btnAddDayExceptionGroup.Text = "addDayExceptionGroup";
            this.btnAddDayExceptionGroup.UseVisualStyleBackColor = true;
            this.btnAddDayExceptionGroup.Click += new System.EventHandler(this.btnAddDayExceptionGroup_Click);
            // 
            // ucDayExceptionViewControl
            // 
            this.ucDayExceptionViewControl.DayException = null;
            this.ucDayExceptionViewControl.Location = new System.Drawing.Point(278, 95);
            this.ucDayExceptionViewControl.Name = "ucDayExceptionViewControl";
            this.ucDayExceptionViewControl.Size = new System.Drawing.Size(175, 199);
            this.ucDayExceptionViewControl.TabIndex = 50;
            // 
            // btnDayExceptionAddTimePeriod
            // 
            this.btnDayExceptionAddTimePeriod.Location = new System.Drawing.Point(16, 119);
            this.btnDayExceptionAddTimePeriod.Name = "btnDayExceptionAddTimePeriod";
            this.btnDayExceptionAddTimePeriod.Size = new System.Drawing.Size(114, 23);
            this.btnDayExceptionAddTimePeriod.TabIndex = 42;
            this.btnDayExceptionAddTimePeriod.Text = "Add Time Period ";
            this.btnDayExceptionAddTimePeriod.UseVisualStyleBackColor = true;
            this.btnDayExceptionAddTimePeriod.Click += new System.EventHandler(this.btnDayExceptionAddTimePeriod_Click);
            // 
            // clbDayExceptionTimePeriods
            // 
            this.clbDayExceptionTimePeriods.FormattingEnabled = true;
            this.clbDayExceptionTimePeriods.Location = new System.Drawing.Point(16, 150);
            this.clbDayExceptionTimePeriods.Name = "clbDayExceptionTimePeriods";
            this.clbDayExceptionTimePeriods.Size = new System.Drawing.Size(321, 169);
            this.clbDayExceptionTimePeriods.TabIndex = 41;
            // 
            // dtpDayExceptionEndTime
            // 
            this.dtpDayExceptionEndTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpDayExceptionEndTime.Location = new System.Drawing.Point(126, 93);
            this.dtpDayExceptionEndTime.Name = "dtpDayExceptionEndTime";
            this.dtpDayExceptionEndTime.ShowUpDown = true;
            this.dtpDayExceptionEndTime.Size = new System.Drawing.Size(93, 20);
            this.dtpDayExceptionEndTime.TabIndex = 40;
            this.dtpDayExceptionEndTime.Value = new System.DateTime(2016, 7, 1, 23, 59, 59, 0);
            // 
            // dtpDayExceptionStartTime
            // 
            this.dtpDayExceptionStartTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpDayExceptionStartTime.Location = new System.Drawing.Point(16, 93);
            this.dtpDayExceptionStartTime.Name = "dtpDayExceptionStartTime";
            this.dtpDayExceptionStartTime.ShowUpDown = true;
            this.dtpDayExceptionStartTime.Size = new System.Drawing.Size(93, 20);
            this.dtpDayExceptionStartTime.TabIndex = 39;
            this.dtpDayExceptionStartTime.Value = new System.DateTime(2016, 7, 1, 0, 0, 0, 0);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(123, 77);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(55, 13);
            this.label17.TabIndex = 38;
            this.label17.Text = "End Time:";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(13, 77);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(58, 13);
            this.label18.TabIndex = 37;
            this.label18.Text = "Start Time:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(13, 34);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(30, 13);
            this.label16.TabIndex = 36;
            this.label16.Text = "Date";
            // 
            // dtpDayExceptionDate
            // 
            this.dtpDayExceptionDate.Location = new System.Drawing.Point(16, 50);
            this.dtpDayExceptionDate.Name = "dtpDayExceptionDate";
            this.dtpDayExceptionDate.Size = new System.Drawing.Size(203, 20);
            this.dtpDayExceptionDate.TabIndex = 33;
            // 
            // btnModifyDayException
            // 
            this.btnModifyDayException.Location = new System.Drawing.Point(243, 74);
            this.btnModifyDayException.Name = "btnModifyDayException";
            this.btnModifyDayException.Size = new System.Drawing.Size(132, 23);
            this.btnModifyDayException.TabIndex = 32;
            this.btnModifyDayException.Text = "modifyDayException";
            this.btnModifyDayException.UseVisualStyleBackColor = true;
            this.btnModifyDayException.Click += new System.EventHandler(this.btnModifyDayException_Click);
            // 
            // btnRemoveDayException
            // 
            this.btnRemoveDayException.Location = new System.Drawing.Point(243, 103);
            this.btnRemoveDayException.Name = "btnRemoveDayException";
            this.btnRemoveDayException.Size = new System.Drawing.Size(132, 23);
            this.btnRemoveDayException.TabIndex = 31;
            this.btnRemoveDayException.Text = "removeDayException";
            this.btnRemoveDayException.UseVisualStyleBackColor = true;
            this.btnRemoveDayException.Click += new System.EventHandler(this.btnRemoveDayException_Click);
            // 
            // cbDayExceptionIdList
            // 
            this.cbDayExceptionIdList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDayExceptionIdList.FormattingEnabled = true;
            this.cbDayExceptionIdList.Location = new System.Drawing.Point(126, 8);
            this.cbDayExceptionIdList.Name = "cbDayExceptionIdList";
            this.cbDayExceptionIdList.Size = new System.Drawing.Size(249, 21);
            this.cbDayExceptionIdList.TabIndex = 30;
            this.cbDayExceptionIdList.SelectedIndexChanged += new System.EventHandler(this.cbDayExceptionIdList_SelectedIndexChanged);
            // 
            // btnAddDayException
            // 
            this.btnAddDayException.Location = new System.Drawing.Point(243, 47);
            this.btnAddDayException.Name = "btnAddDayException";
            this.btnAddDayException.Size = new System.Drawing.Size(132, 23);
            this.btnAddDayException.TabIndex = 29;
            this.btnAddDayException.Text = "addDayException";
            this.btnAddDayException.UseVisualStyleBackColor = true;
            this.btnAddDayException.Click += new System.EventHandler(this.btnAddDayException_Click);
            // 
            // btnGetDayExceptionIds
            // 
            this.btnGetDayExceptionIds.Location = new System.Drawing.Point(3, 6);
            this.btnGetDayExceptionIds.Name = "btnGetDayExceptionIds";
            this.btnGetDayExceptionIds.Size = new System.Drawing.Size(117, 25);
            this.btnGetDayExceptionIds.TabIndex = 28;
            this.btnGetDayExceptionIds.Text = "getDayExceptionIds";
            this.btnGetDayExceptionIds.UseVisualStyleBackColor = true;
            this.btnGetDayExceptionIds.Click += new System.EventHandler(this.btnGetDayExceptionIds_Click);
            // 
            // tabPageSchedules
            // 
            this.tabPageSchedules.Controls.Add(this.btnRemoveDayExceptionGroupFromSchedule);
            this.tabPageSchedules.Controls.Add(this.btnAddDayExceptionGroupToSchedule);
            this.tabPageSchedules.Controls.Add(this.btnRemoveDayPeriodFromSchedule);
            this.tabPageSchedules.Controls.Add(this.btnAddDayPeriodToSchedule);
            this.tabPageSchedules.Controls.Add(this.label22);
            this.tabPageSchedules.Controls.Add(this.ucScheduleDayExceptionViewControl);
            this.tabPageSchedules.Controls.Add(this.lbScheduleDayExceptionGroupDayExceptions);
            this.tabPageSchedules.Controls.Add(this.label21);
            this.tabPageSchedules.Controls.Add(this.label19);
            this.tabPageSchedules.Controls.Add(this.scheduleDayPeriodViewControl);
            this.tabPageSchedules.Controls.Add(this.clbScheduleDayExceptionGroupIdList);
            this.tabPageSchedules.Controls.Add(this.clbScheduleDayPeriodCheckedListBox);
            this.tabPageSchedules.Controls.Add(this.btnModifySchedule);
            this.tabPageSchedules.Controls.Add(this.btnRemoveSchedule);
            this.tabPageSchedules.Controls.Add(this.cbScheduleIdList);
            this.tabPageSchedules.Controls.Add(this.btnAddSchedule);
            this.tabPageSchedules.Controls.Add(this.btnGetScheduleIds);
            this.tabPageSchedules.Location = new System.Drawing.Point(4, 22);
            this.tabPageSchedules.Name = "tabPageSchedules";
            this.tabPageSchedules.Size = new System.Drawing.Size(1021, 353);
            this.tabPageSchedules.TabIndex = 3;
            this.tabPageSchedules.Text = "Schedules";
            this.tabPageSchedules.UseVisualStyleBackColor = true;
            // 
            // btnRemoveDayExceptionGroupFromSchedule
            // 
            this.btnRemoveDayExceptionGroupFromSchedule.Enabled = false;
            this.btnRemoveDayExceptionGroupFromSchedule.Location = new System.Drawing.Point(774, 86);
            this.btnRemoveDayExceptionGroupFromSchedule.Name = "btnRemoveDayExceptionGroupFromSchedule";
            this.btnRemoveDayExceptionGroupFromSchedule.Size = new System.Drawing.Size(227, 23);
            this.btnRemoveDayExceptionGroupFromSchedule.TabIndex = 58;
            this.btnRemoveDayExceptionGroupFromSchedule.Text = "removeDayExceptionGroupFromSchedule";
            this.btnRemoveDayExceptionGroupFromSchedule.UseVisualStyleBackColor = true;
            this.btnRemoveDayExceptionGroupFromSchedule.Click += new System.EventHandler(this.btnRemoveDayExceptionGroupFromSchedule_Click);
            // 
            // btnAddDayExceptionGroupToSchedule
            // 
            this.btnAddDayExceptionGroupToSchedule.Enabled = false;
            this.btnAddDayExceptionGroupToSchedule.Location = new System.Drawing.Point(774, 57);
            this.btnAddDayExceptionGroupToSchedule.Name = "btnAddDayExceptionGroupToSchedule";
            this.btnAddDayExceptionGroupToSchedule.Size = new System.Drawing.Size(227, 23);
            this.btnAddDayExceptionGroupToSchedule.TabIndex = 57;
            this.btnAddDayExceptionGroupToSchedule.Text = "addDayExceptionGroupToSchedule";
            this.btnAddDayExceptionGroupToSchedule.UseVisualStyleBackColor = true;
            this.btnAddDayExceptionGroupToSchedule.Click += new System.EventHandler(this.btnAddDayExceptionGroupToSchedule_Click);
            // 
            // btnRemoveDayPeriodFromSchedule
            // 
            this.btnRemoveDayPeriodFromSchedule.Enabled = false;
            this.btnRemoveDayPeriodFromSchedule.Location = new System.Drawing.Point(235, 86);
            this.btnRemoveDayPeriodFromSchedule.Name = "btnRemoveDayPeriodFromSchedule";
            this.btnRemoveDayPeriodFromSchedule.Size = new System.Drawing.Size(194, 23);
            this.btnRemoveDayPeriodFromSchedule.TabIndex = 56;
            this.btnRemoveDayPeriodFromSchedule.Text = "removeDayPeriodFromSchedule";
            this.btnRemoveDayPeriodFromSchedule.UseVisualStyleBackColor = true;
            this.btnRemoveDayPeriodFromSchedule.Click += new System.EventHandler(this.btnRemoveDayPeriodFromSchedule_Click);
            // 
            // btnAddDayPeriodToSchedule
            // 
            this.btnAddDayPeriodToSchedule.Enabled = false;
            this.btnAddDayPeriodToSchedule.Location = new System.Drawing.Point(235, 57);
            this.btnAddDayPeriodToSchedule.Name = "btnAddDayPeriodToSchedule";
            this.btnAddDayPeriodToSchedule.Size = new System.Drawing.Size(194, 23);
            this.btnAddDayPeriodToSchedule.TabIndex = 55;
            this.btnAddDayPeriodToSchedule.Text = "addDayPeriodToSchedule";
            this.btnAddDayPeriodToSchedule.UseVisualStyleBackColor = true;
            this.btnAddDayPeriodToSchedule.Click += new System.EventHandler(this.btnAddDayPeriodToSchedule_Click);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(470, 206);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(154, 13);
            this.label22.TabIndex = 54;
            this.label22.Text = "Group Member Day Exceptions";
            // 
            // ucScheduleDayExceptionViewControl
            // 
            this.ucScheduleDayExceptionViewControl.DayException = null;
            this.ucScheduleDayExceptionViewControl.Location = new System.Drawing.Point(774, 115);
            this.ucScheduleDayExceptionViewControl.Name = "ucScheduleDayExceptionViewControl";
            this.ucScheduleDayExceptionViewControl.Size = new System.Drawing.Size(175, 199);
            this.ucScheduleDayExceptionViewControl.TabIndex = 53;
            // 
            // lbScheduleDayExceptionGroupDayExceptions
            // 
            this.lbScheduleDayExceptionGroupDayExceptions.FormattingEnabled = true;
            this.lbScheduleDayExceptionGroupDayExceptions.Location = new System.Drawing.Point(473, 222);
            this.lbScheduleDayExceptionGroupDayExceptions.Name = "lbScheduleDayExceptionGroupDayExceptions";
            this.lbScheduleDayExceptionGroupDayExceptions.Size = new System.Drawing.Size(284, 69);
            this.lbScheduleDayExceptionGroupDayExceptions.TabIndex = 52;
            this.lbScheduleDayExceptionGroupDayExceptions.SelectedIndexChanged += new System.EventHandler(this.lbScheduleDayExceptionGroupDayExceptions_SelectedIndexChanged);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(3, 41);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(64, 13);
            this.label21.TabIndex = 50;
            this.label21.Text = "Day Periods";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(470, 41);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(113, 13);
            this.label19.TabIndex = 35;
            this.label19.Text = "Day Exception Groups";
            // 
            // scheduleDayPeriodViewControl
            // 
            this.scheduleDayPeriodViewControl.DayPeriod = null;
            this.scheduleDayPeriodViewControl.Location = new System.Drawing.Point(3, 172);
            this.scheduleDayPeriodViewControl.Name = "scheduleDayPeriodViewControl";
            this.scheduleDayPeriodViewControl.Size = new System.Drawing.Size(355, 130);
            this.scheduleDayPeriodViewControl.TabIndex = 51;
            // 
            // clbScheduleDayExceptionGroupIdList
            // 
            this.clbScheduleDayExceptionGroupIdList.FormattingEnabled = true;
            this.clbScheduleDayExceptionGroupIdList.Location = new System.Drawing.Point(473, 57);
            this.clbScheduleDayExceptionGroupIdList.Name = "clbScheduleDayExceptionGroupIdList";
            this.clbScheduleDayExceptionGroupIdList.Size = new System.Drawing.Size(284, 139);
            this.clbScheduleDayExceptionGroupIdList.TabIndex = 34;
            this.clbScheduleDayExceptionGroupIdList.SelectedIndexChanged += new System.EventHandler(this.clbScheduleDayExceptionGroupIdList_SelectedIndexChanged);
            // 
            // clbScheduleDayPeriodCheckedListBox
            // 
            this.clbScheduleDayPeriodCheckedListBox.FormattingEnabled = true;
            this.clbScheduleDayPeriodCheckedListBox.Location = new System.Drawing.Point(3, 57);
            this.clbScheduleDayPeriodCheckedListBox.Name = "clbScheduleDayPeriodCheckedListBox";
            this.clbScheduleDayPeriodCheckedListBox.Size = new System.Drawing.Size(215, 109);
            this.clbScheduleDayPeriodCheckedListBox.TabIndex = 33;
            this.clbScheduleDayPeriodCheckedListBox.SelectedIndexChanged += new System.EventHandler(this.ScheduleDayPeriodCheckedListBox_SelectedIndexChanged);
            // 
            // btnModifySchedule
            // 
            this.btnModifySchedule.Location = new System.Drawing.Point(604, 7);
            this.btnModifySchedule.Name = "btnModifySchedule";
            this.btnModifySchedule.Size = new System.Drawing.Size(107, 23);
            this.btnModifySchedule.TabIndex = 32;
            this.btnModifySchedule.Text = "modifySchedule";
            this.btnModifySchedule.UseVisualStyleBackColor = true;
            this.btnModifySchedule.Click += new System.EventHandler(this.btnModifySchedule_Click);
            // 
            // btnRemoveSchedule
            // 
            this.btnRemoveSchedule.Location = new System.Drawing.Point(378, 7);
            this.btnRemoveSchedule.Name = "btnRemoveSchedule";
            this.btnRemoveSchedule.Size = new System.Drawing.Size(107, 23);
            this.btnRemoveSchedule.TabIndex = 31;
            this.btnRemoveSchedule.Text = "removeSchedule";
            this.btnRemoveSchedule.UseVisualStyleBackColor = true;
            this.btnRemoveSchedule.Click += new System.EventHandler(this.btnRemoveSchedule_Click);
            // 
            // cbScheduleIdList
            // 
            this.cbScheduleIdList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbScheduleIdList.FormattingEnabled = true;
            this.cbScheduleIdList.Location = new System.Drawing.Point(116, 7);
            this.cbScheduleIdList.Name = "cbScheduleIdList";
            this.cbScheduleIdList.Size = new System.Drawing.Size(249, 21);
            this.cbScheduleIdList.TabIndex = 30;
            this.cbScheduleIdList.SelectedIndexChanged += new System.EventHandler(this.cbScheduleIdList_SelectedIndexChanged);
            // 
            // btnAddSchedule
            // 
            this.btnAddSchedule.Location = new System.Drawing.Point(491, 7);
            this.btnAddSchedule.Name = "btnAddSchedule";
            this.btnAddSchedule.Size = new System.Drawing.Size(107, 23);
            this.btnAddSchedule.TabIndex = 29;
            this.btnAddSchedule.Text = "addSchedule";
            this.btnAddSchedule.UseVisualStyleBackColor = true;
            this.btnAddSchedule.Click += new System.EventHandler(this.btnAddSchedule_Click);
            // 
            // btnGetScheduleIds
            // 
            this.btnGetScheduleIds.Location = new System.Drawing.Point(3, 5);
            this.btnGetScheduleIds.Name = "btnGetScheduleIds";
            this.btnGetScheduleIds.Size = new System.Drawing.Size(103, 23);
            this.btnGetScheduleIds.TabIndex = 28;
            this.btnGetScheduleIds.Text = "getScheduleIds";
            this.btnGetScheduleIds.UseVisualStyleBackColor = true;
            this.btnGetScheduleIds.Click += new System.EventHandler(this.btnGetScheduleIds_Click);
            // 
            // tabPageAuthorizations
            // 
            this.tabPageAuthorizations.Controls.Add(this.txtToggleAuthIncCount);
            this.tabPageAuthorizations.Controls.Add(this.btnToggleAllAccessPointsAuthorization);
            this.tabPageAuthorizations.Controls.Add(this.btnToggleAllUsersAuthorization);
            this.tabPageAuthorizations.Controls.Add(this.label43);
            this.tabPageAuthorizations.Controls.Add(this.txtUseCount);
            this.tabPageAuthorizations.Controls.Add(this.btnSetAuthorizationTypeForAuthorization);
            this.tabPageAuthorizations.Controls.Add(this.btnSetNewScheduleInAuthorization);
            this.tabPageAuthorizations.Controls.Add(this.btnremoveAccessPointsFromAuthorization);
            this.tabPageAuthorizations.Controls.Add(this.btnaddAccessPointsToAuthorization);
            this.tabPageAuthorizations.Controls.Add(this.btnremoveUsersFromAuthorization);
            this.tabPageAuthorizations.Controls.Add(this.btnaddUsersToAuthorization);
            this.tabPageAuthorizations.Controls.Add(this.label30);
            this.tabPageAuthorizations.Controls.Add(this.cbAuthorizationAuthorizationSchedule);
            this.tabPageAuthorizations.Controls.Add(this.label31);
            this.tabPageAuthorizations.Controls.Add(this.cbAuthorizationAuthorizationType);
            this.tabPageAuthorizations.Controls.Add(this.label29);
            this.tabPageAuthorizations.Controls.Add(this.clbAuthorizationAuthorizeUsers);
            this.tabPageAuthorizations.Controls.Add(this.label28);
            this.tabPageAuthorizations.Controls.Add(this.clbAuthorizationAuthorizeAccessPoints);
            this.tabPageAuthorizations.Controls.Add(this.btnModifyAuthorization);
            this.tabPageAuthorizations.Controls.Add(this.btnRemoveAuthorization);
            this.tabPageAuthorizations.Controls.Add(this.cbAuthorizationIdList);
            this.tabPageAuthorizations.Controls.Add(this.btnAddAuthorization);
            this.tabPageAuthorizations.Controls.Add(this.btnAuthorizeAllUsersAllLocks);
            this.tabPageAuthorizations.Controls.Add(this.btnGetAuthorizationIds);
            this.tabPageAuthorizations.Location = new System.Drawing.Point(4, 22);
            this.tabPageAuthorizations.Name = "tabPageAuthorizations";
            this.tabPageAuthorizations.Size = new System.Drawing.Size(1021, 353);
            this.tabPageAuthorizations.TabIndex = 2;
            this.tabPageAuthorizations.Text = "Authorizations";
            this.tabPageAuthorizations.UseVisualStyleBackColor = true;
            // 
            // txtToggleAuthIncCount
            // 
            this.txtToggleAuthIncCount.Location = new System.Drawing.Point(518, 47);
            this.txtToggleAuthIncCount.Name = "txtToggleAuthIncCount";
            this.txtToggleAuthIncCount.Size = new System.Drawing.Size(49, 20);
            this.txtToggleAuthIncCount.TabIndex = 78;
            this.txtToggleAuthIncCount.Text = "1";
            // 
            // btnToggleAllAccessPointsAuthorization
            // 
            this.btnToggleAllAccessPointsAuthorization.Location = new System.Drawing.Point(786, 43);
            this.btnToggleAllAccessPointsAuthorization.Name = "btnToggleAllAccessPointsAuthorization";
            this.btnToggleAllAccessPointsAuthorization.Size = new System.Drawing.Size(167, 23);
            this.btnToggleAllAccessPointsAuthorization.TabIndex = 77;
            this.btnToggleAllAccessPointsAuthorization.Text = "Toggle All Access Points";
            this.btnToggleAllAccessPointsAuthorization.UseVisualStyleBackColor = true;
            this.btnToggleAllAccessPointsAuthorization.Click += new System.EventHandler(this.btnToggleAllAccessPointsAuthorization_Click);
            // 
            // btnToggleAllUsersAuthorization
            // 
            this.btnToggleAllUsersAuthorization.Location = new System.Drawing.Point(396, 49);
            this.btnToggleAllUsersAuthorization.Name = "btnToggleAllUsersAuthorization";
            this.btnToggleAllUsersAuthorization.Size = new System.Drawing.Size(107, 23);
            this.btnToggleAllUsersAuthorization.TabIndex = 76;
            this.btnToggleAllUsersAuthorization.Text = "Toggle All Users";
            this.btnToggleAllUsersAuthorization.UseVisualStyleBackColor = true;
            this.btnToggleAllUsersAuthorization.Click += new System.EventHandler(this.btnToggleAllUsersAuthorization_Click);
            // 
            // label43
            // 
            this.label43.AutoSize = true;
            this.label43.Location = new System.Drawing.Point(13, 224);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(57, 13);
            this.label43.TabIndex = 75;
            this.label43.Text = "Use Count";
            // 
            // txtUseCount
            // 
            this.txtUseCount.Location = new System.Drawing.Point(16, 240);
            this.txtUseCount.Name = "txtUseCount";
            this.txtUseCount.Size = new System.Drawing.Size(49, 20);
            this.txtUseCount.TabIndex = 74;
            this.txtUseCount.Text = "0";
            // 
            // btnSetAuthorizationTypeForAuthorization
            // 
            this.btnSetAuthorizationTypeForAuthorization.Location = new System.Drawing.Point(13, 99);
            this.btnSetAuthorizationTypeForAuthorization.Name = "btnSetAuthorizationTypeForAuthorization";
            this.btnSetAuthorizationTypeForAuthorization.Size = new System.Drawing.Size(202, 23);
            this.btnSetAuthorizationTypeForAuthorization.TabIndex = 73;
            this.btnSetAuthorizationTypeForAuthorization.Text = "setAuthorizationTypeForAuthorization";
            this.btnSetAuthorizationTypeForAuthorization.UseVisualStyleBackColor = true;
            this.btnSetAuthorizationTypeForAuthorization.Click += new System.EventHandler(this.btnSetAuthorizationTypeForAuthorization_Click);
            // 
            // btnSetNewScheduleInAuthorization
            // 
            this.btnSetNewScheduleInAuthorization.Location = new System.Drawing.Point(16, 190);
            this.btnSetNewScheduleInAuthorization.Name = "btnSetNewScheduleInAuthorization";
            this.btnSetNewScheduleInAuthorization.Size = new System.Drawing.Size(188, 23);
            this.btnSetNewScheduleInAuthorization.TabIndex = 72;
            this.btnSetNewScheduleInAuthorization.Text = "setNewScheduleInAuthorization";
            this.btnSetNewScheduleInAuthorization.UseVisualStyleBackColor = true;
            this.btnSetNewScheduleInAuthorization.Click += new System.EventHandler(this.btnSetNewScheduleInAuthorization_Click);
            // 
            // btnremoveAccessPointsFromAuthorization
            // 
            this.btnremoveAccessPointsFromAuthorization.Location = new System.Drawing.Point(802, 322);
            this.btnremoveAccessPointsFromAuthorization.Name = "btnremoveAccessPointsFromAuthorization";
            this.btnremoveAccessPointsFromAuthorization.Size = new System.Drawing.Size(204, 23);
            this.btnremoveAccessPointsFromAuthorization.TabIndex = 71;
            this.btnremoveAccessPointsFromAuthorization.Text = "removeAccessPointsFromAuthorization";
            this.btnremoveAccessPointsFromAuthorization.UseVisualStyleBackColor = true;
            this.btnremoveAccessPointsFromAuthorization.Click += new System.EventHandler(this.btnremoveAccessPointsFromAuthorization_Click);
            // 
            // btnaddAccessPointsToAuthorization
            // 
            this.btnaddAccessPointsToAuthorization.Location = new System.Drawing.Point(619, 322);
            this.btnaddAccessPointsToAuthorization.Name = "btnaddAccessPointsToAuthorization";
            this.btnaddAccessPointsToAuthorization.Size = new System.Drawing.Size(177, 23);
            this.btnaddAccessPointsToAuthorization.TabIndex = 70;
            this.btnaddAccessPointsToAuthorization.Text = "addAccessPointsToAuthorization";
            this.btnaddAccessPointsToAuthorization.UseVisualStyleBackColor = true;
            this.btnaddAccessPointsToAuthorization.Click += new System.EventHandler(this.btnaddAccessPointsToAuthorization_Click);
            // 
            // btnremoveUsersFromAuthorization
            // 
            this.btnremoveUsersFromAuthorization.Location = new System.Drawing.Point(421, 322);
            this.btnremoveUsersFromAuthorization.Name = "btnremoveUsersFromAuthorization";
            this.btnremoveUsersFromAuthorization.Size = new System.Drawing.Size(161, 23);
            this.btnremoveUsersFromAuthorization.TabIndex = 69;
            this.btnremoveUsersFromAuthorization.Text = "removeUsersFromAuthorization";
            this.btnremoveUsersFromAuthorization.UseVisualStyleBackColor = true;
            this.btnremoveUsersFromAuthorization.Click += new System.EventHandler(this.btnremoveUsersFromAuthorization_Click);
            // 
            // btnaddUsersToAuthorization
            // 
            this.btnaddUsersToAuthorization.Location = new System.Drawing.Point(238, 322);
            this.btnaddUsersToAuthorization.Name = "btnaddUsersToAuthorization";
            this.btnaddUsersToAuthorization.Size = new System.Drawing.Size(161, 23);
            this.btnaddUsersToAuthorization.TabIndex = 68;
            this.btnaddUsersToAuthorization.Text = "addUsersToAuthorization";
            this.btnaddUsersToAuthorization.UseVisualStyleBackColor = true;
            this.btnaddUsersToAuthorization.Click += new System.EventHandler(this.btnaddUsersToAuthorization_Click);
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(13, 136);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(52, 13);
            this.label30.TabIndex = 67;
            this.label30.Text = "Schedule";
            // 
            // cbAuthorizationAuthorizationSchedule
            // 
            this.cbAuthorizationAuthorizationSchedule.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAuthorizationAuthorizationSchedule.FormattingEnabled = true;
            this.cbAuthorizationAuthorizationSchedule.Location = new System.Drawing.Point(16, 152);
            this.cbAuthorizationAuthorizationSchedule.Name = "cbAuthorizationAuthorizationSchedule";
            this.cbAuthorizationAuthorizationSchedule.Size = new System.Drawing.Size(188, 21);
            this.cbAuthorizationAuthorizationSchedule.TabIndex = 66;
            this.cbAuthorizationAuthorizationSchedule.SelectedIndexChanged += new System.EventHandler(this.cbAuthorizationAuthorizationSchedule_SelectedIndexChanged);
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(13, 56);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(95, 13);
            this.label31.TabIndex = 65;
            this.label31.Text = "Authorization Type";
            // 
            // cbAuthorizationAuthorizationType
            // 
            this.cbAuthorizationAuthorizationType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAuthorizationAuthorizationType.FormattingEnabled = true;
            this.cbAuthorizationAuthorizationType.Location = new System.Drawing.Point(13, 72);
            this.cbAuthorizationAuthorizationType.Name = "cbAuthorizationAuthorizationType";
            this.cbAuthorizationAuthorizationType.Size = new System.Drawing.Size(188, 21);
            this.cbAuthorizationAuthorizationType.TabIndex = 64;
            this.cbAuthorizationAuthorizationType.SelectedIndexChanged += new System.EventHandler(this.cbAuthorizationAuthorizationType_SelectedIndexChanged);
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(235, 56);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(87, 13);
            this.label29.TabIndex = 63;
            this.label29.Text = "Authorized Users";
            // 
            // clbAuthorizationAuthorizeUsers
            // 
            this.clbAuthorizationAuthorizeUsers.FormattingEnabled = true;
            this.clbAuthorizationAuthorizeUsers.Location = new System.Drawing.Point(235, 72);
            this.clbAuthorizationAuthorizeUsers.Name = "clbAuthorizationAuthorizeUsers";
            this.clbAuthorizationAuthorizeUsers.Size = new System.Drawing.Size(373, 244);
            this.clbAuthorizationAuthorizeUsers.TabIndex = 62;
            this.clbAuthorizationAuthorizeUsers.SelectedIndexChanged += new System.EventHandler(this.clbAuthorizationAuthorizeUsers_SelectedIndexChanged);
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(628, 56);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(127, 13);
            this.label28.TabIndex = 61;
            this.label28.Text = "Authorized Access Points";
            // 
            // clbAuthorizationAuthorizeAccessPoints
            // 
            this.clbAuthorizationAuthorizeAccessPoints.FormattingEnabled = true;
            this.clbAuthorizationAuthorizeAccessPoints.Location = new System.Drawing.Point(628, 72);
            this.clbAuthorizationAuthorizeAccessPoints.Name = "clbAuthorizationAuthorizeAccessPoints";
            this.clbAuthorizationAuthorizeAccessPoints.Size = new System.Drawing.Size(373, 244);
            this.clbAuthorizationAuthorizeAccessPoints.TabIndex = 60;
            this.clbAuthorizationAuthorizeAccessPoints.SelectedIndexChanged += new System.EventHandler(this.clbAuthorizationAuthorizeAccessPoints_SelectedIndexChanged);
            // 
            // btnModifyAuthorization
            // 
            this.btnModifyAuthorization.Location = new System.Drawing.Point(518, 18);
            this.btnModifyAuthorization.Name = "btnModifyAuthorization";
            this.btnModifyAuthorization.Size = new System.Drawing.Size(107, 23);
            this.btnModifyAuthorization.TabIndex = 31;
            this.btnModifyAuthorization.Text = "modifyAuthorization";
            this.btnModifyAuthorization.UseVisualStyleBackColor = true;
            this.btnModifyAuthorization.Click += new System.EventHandler(this.btnModifyAuthorization_Click);
            // 
            // btnRemoveAuthorization
            // 
            this.btnRemoveAuthorization.Location = new System.Drawing.Point(631, 20);
            this.btnRemoveAuthorization.Name = "btnRemoveAuthorization";
            this.btnRemoveAuthorization.Size = new System.Drawing.Size(107, 23);
            this.btnRemoveAuthorization.TabIndex = 30;
            this.btnRemoveAuthorization.Text = "removeAuthorization";
            this.btnRemoveAuthorization.UseVisualStyleBackColor = true;
            this.btnRemoveAuthorization.Click += new System.EventHandler(this.btnRemoveAuthorization_Click);
            // 
            // cbAuthorizationIdList
            // 
            this.cbAuthorizationIdList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAuthorizationIdList.FormattingEnabled = true;
            this.cbAuthorizationIdList.Location = new System.Drawing.Point(150, 20);
            this.cbAuthorizationIdList.Name = "cbAuthorizationIdList";
            this.cbAuthorizationIdList.Size = new System.Drawing.Size(249, 21);
            this.cbAuthorizationIdList.TabIndex = 29;
            this.cbAuthorizationIdList.SelectedIndexChanged += new System.EventHandler(this.cbAuthorizationIdList_SelectedIndexChanged);
            // 
            // btnAddAuthorization
            // 
            this.btnAddAuthorization.Location = new System.Drawing.Point(405, 20);
            this.btnAddAuthorization.Name = "btnAddAuthorization";
            this.btnAddAuthorization.Size = new System.Drawing.Size(107, 23);
            this.btnAddAuthorization.TabIndex = 28;
            this.btnAddAuthorization.Text = "addAuthorization";
            this.btnAddAuthorization.UseVisualStyleBackColor = true;
            this.btnAddAuthorization.Click += new System.EventHandler(this.btnAddAuthorization_Click);
            // 
            // btnAuthorizeAllUsersAllLocks
            // 
            this.btnAuthorizeAllUsersAllLocks.Location = new System.Drawing.Point(13, 288);
            this.btnAuthorizeAllUsersAllLocks.Name = "btnAuthorizeAllUsersAllLocks";
            this.btnAuthorizeAllUsersAllLocks.Size = new System.Drawing.Size(188, 23);
            this.btnAuthorizeAllUsersAllLocks.TabIndex = 1;
            this.btnAuthorizeAllUsersAllLocks.Text = "Authorize All Users All Locks";
            this.btnAuthorizeAllUsersAllLocks.UseVisualStyleBackColor = true;
            this.btnAuthorizeAllUsersAllLocks.Click += new System.EventHandler(this.btnAuthorizeAllUsersAllLocks_Click);
            // 
            // btnGetAuthorizationIds
            // 
            this.btnGetAuthorizationIds.Location = new System.Drawing.Point(13, 20);
            this.btnGetAuthorizationIds.Name = "btnGetAuthorizationIds";
            this.btnGetAuthorizationIds.Size = new System.Drawing.Size(129, 23);
            this.btnGetAuthorizationIds.TabIndex = 0;
            this.btnGetAuthorizationIds.Text = "getAuthorizationIds";
            this.btnGetAuthorizationIds.UseVisualStyleBackColor = true;
            this.btnGetAuthorizationIds.Click += new System.EventHandler(this.btnGetAuthorizationIds_Click);
            // 
            // tabPageAccessPointSpecificOperations
            // 
            this.tabPageAccessPointSpecificOperations.Controls.Add(this.btnACGetNewLogsRepeatForDSR);
            this.tabPageAccessPointSpecificOperations.Controls.Add(this.tabControl3);
            this.tabPageAccessPointSpecificOperations.Controls.Add(this.btnACGetNewLogsRepeat);
            this.tabPageAccessPointSpecificOperations.Controls.Add(this.btnSetAllLocksAccessPrimaryOnlyMode);
            this.tabPageAccessPointSpecificOperations.Controls.Add(this.grpAccessControlAccessPointOperations);
            this.tabPageAccessPointSpecificOperations.Controls.Add(this.btnACGetNewLogs);
            this.tabPageAccessPointSpecificOperations.Controls.Add(this.label2);
            this.tabPageAccessPointSpecificOperations.Controls.Add(this.cbAccessControlServiceAccessPoints);
            this.tabPageAccessPointSpecificOperations.Location = new System.Drawing.Point(4, 22);
            this.tabPageAccessPointSpecificOperations.Name = "tabPageAccessPointSpecificOperations";
            this.tabPageAccessPointSpecificOperations.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageAccessPointSpecificOperations.Size = new System.Drawing.Size(1021, 353);
            this.tabPageAccessPointSpecificOperations.TabIndex = 6;
            this.tabPageAccessPointSpecificOperations.Text = "Access Point Specific Operations";
            this.tabPageAccessPointSpecificOperations.UseVisualStyleBackColor = true;
            // 
            // btnACGetNewLogsRepeatForDSR
            // 
            this.btnACGetNewLogsRepeatForDSR.Location = new System.Drawing.Point(765, 6);
            this.btnACGetNewLogsRepeatForDSR.Name = "btnACGetNewLogsRepeatForDSR";
            this.btnACGetNewLogsRepeatForDSR.Size = new System.Drawing.Size(250, 23);
            this.btnACGetNewLogsRepeatForDSR.TabIndex = 26;
            this.btnACGetNewLogsRepeatForDSR.Text = "getNewLogsUntilCurrent (Entire DSR)";
            this.btnACGetNewLogsRepeatForDSR.UseVisualStyleBackColor = true;
            this.btnACGetNewLogsRepeatForDSR.Click += new System.EventHandler(this.btnACGetNewLogsRepeatForDSR_Click);
            // 
            // tabControl3
            // 
            this.tabControl3.Controls.Add(this.tabPageAlarms);
            this.tabControl3.Controls.Add(this.tabPageFilters);
            this.tabControl3.Controls.Add(this.tabPageScheduler);
            this.tabControl3.Location = new System.Drawing.Point(541, 38);
            this.tabControl3.Name = "tabControl3";
            this.tabControl3.SelectedIndex = 0;
            this.tabControl3.Size = new System.Drawing.Size(474, 309);
            this.tabControl3.TabIndex = 25;
            // 
            // tabPageAlarms
            // 
            this.tabPageAlarms.Controls.Add(this.groupBox4);
            this.tabPageAlarms.Location = new System.Drawing.Point(4, 22);
            this.tabPageAlarms.Name = "tabPageAlarms";
            this.tabPageAlarms.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageAlarms.Size = new System.Drawing.Size(466, 283);
            this.tabPageAlarms.TabIndex = 0;
            this.tabPageAlarms.Text = "Alarms";
            this.tabPageAlarms.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label38);
            this.groupBox4.Controls.Add(this.btnSetFilters);
            this.groupBox4.Controls.Add(this.label37);
            this.groupBox4.Controls.Add(this.label36);
            this.groupBox4.Controls.Add(this.clbRXHeldModeAlarms);
            this.groupBox4.Controls.Add(this.clbPassageModeAlarms);
            this.groupBox4.Controls.Add(this.clbSecuredModeAlarms);
            this.groupBox4.Controls.Add(this.btnSetAlarms);
            this.groupBox4.Location = new System.Drawing.Point(6, 6);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(437, 284);
            this.groupBox4.TabIndex = 24;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Alarms";
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.Location = new System.Drawing.Point(285, 21);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(77, 13);
            this.label38.TabIndex = 28;
            this.label38.Text = "RX Held Mode";
            // 
            // btnSetFilters
            // 
            this.btnSetFilters.Location = new System.Drawing.Point(329, 240);
            this.btnSetFilters.Name = "btnSetFilters";
            this.btnSetFilters.Size = new System.Drawing.Size(102, 23);
            this.btnSetFilters.TabIndex = 22;
            this.btnSetFilters.Text = "Set Filters";
            this.btnSetFilters.UseVisualStyleBackColor = true;
            this.btnSetFilters.Click += new System.EventHandler(this.btnSetFilters_Click);
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Location = new System.Drawing.Point(144, 19);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(78, 13);
            this.label37.TabIndex = 27;
            this.label37.Text = "Passage Mode";
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Location = new System.Drawing.Point(8, 19);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(77, 13);
            this.label36.TabIndex = 26;
            this.label36.Text = "Secured Mode";
            // 
            // clbRXHeldModeAlarms
            // 
            this.clbRXHeldModeAlarms.FormattingEnabled = true;
            this.clbRXHeldModeAlarms.Location = new System.Drawing.Point(288, 35);
            this.clbRXHeldModeAlarms.Name = "clbRXHeldModeAlarms";
            this.clbRXHeldModeAlarms.Size = new System.Drawing.Size(135, 199);
            this.clbRXHeldModeAlarms.TabIndex = 26;
            // 
            // clbPassageModeAlarms
            // 
            this.clbPassageModeAlarms.FormattingEnabled = true;
            this.clbPassageModeAlarms.Location = new System.Drawing.Point(147, 35);
            this.clbPassageModeAlarms.Name = "clbPassageModeAlarms";
            this.clbPassageModeAlarms.Size = new System.Drawing.Size(135, 199);
            this.clbPassageModeAlarms.TabIndex = 25;
            // 
            // clbSecuredModeAlarms
            // 
            this.clbSecuredModeAlarms.FormattingEnabled = true;
            this.clbSecuredModeAlarms.Location = new System.Drawing.Point(6, 35);
            this.clbSecuredModeAlarms.Name = "clbSecuredModeAlarms";
            this.clbSecuredModeAlarms.Size = new System.Drawing.Size(135, 199);
            this.clbSecuredModeAlarms.TabIndex = 24;
            // 
            // btnSetAlarms
            // 
            this.btnSetAlarms.Location = new System.Drawing.Point(6, 240);
            this.btnSetAlarms.Name = "btnSetAlarms";
            this.btnSetAlarms.Size = new System.Drawing.Size(102, 23);
            this.btnSetAlarms.TabIndex = 23;
            this.btnSetAlarms.Text = "Set Alarms";
            this.btnSetAlarms.UseVisualStyleBackColor = true;
            this.btnSetAlarms.Click += new System.EventHandler(this.btnSetAlarms_Click);
            // 
            // tabPageFilters
            // 
            this.tabPageFilters.Location = new System.Drawing.Point(4, 22);
            this.tabPageFilters.Name = "tabPageFilters";
            this.tabPageFilters.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageFilters.Size = new System.Drawing.Size(466, 283);
            this.tabPageFilters.TabIndex = 1;
            this.tabPageFilters.Text = "Filters";
            this.tabPageFilters.UseVisualStyleBackColor = true;
            // 
            // tabPageScheduler
            // 
            this.tabPageScheduler.Controls.Add(this.btnSetAccessPointSchedulerSimple);
            this.tabPageScheduler.Controls.Add(this.label41);
            this.tabPageScheduler.Controls.Add(this.txtAccessPointSimpleConnectMinutes);
            this.tabPageScheduler.Controls.Add(this.label40);
            this.tabPageScheduler.Controls.Add(this.btnLoadAccessPointSchedulerData);
            this.tabPageScheduler.Controls.Add(this.cbAccessPointScheduler);
            this.tabPageScheduler.Controls.Add(this.label39);
            this.tabPageScheduler.Location = new System.Drawing.Point(4, 22);
            this.tabPageScheduler.Name = "tabPageScheduler";
            this.tabPageScheduler.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageScheduler.Size = new System.Drawing.Size(466, 283);
            this.tabPageScheduler.TabIndex = 2;
            this.tabPageScheduler.Text = "Wakeup Scheduler";
            this.tabPageScheduler.UseVisualStyleBackColor = true;
            // 
            // btnSetAccessPointSchedulerSimple
            // 
            this.btnSetAccessPointSchedulerSimple.Location = new System.Drawing.Point(328, 31);
            this.btnSetAccessPointSchedulerSimple.Name = "btnSetAccessPointSchedulerSimple";
            this.btnSetAccessPointSchedulerSimple.Size = new System.Drawing.Size(75, 23);
            this.btnSetAccessPointSchedulerSimple.TabIndex = 26;
            this.btnSetAccessPointSchedulerSimple.Text = "<- Set";
            this.btnSetAccessPointSchedulerSimple.UseVisualStyleBackColor = true;
            this.btnSetAccessPointSchedulerSimple.Click += new System.EventHandler(this.btnSetAccessPointSchedulerSimple_Click);
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.Location = new System.Drawing.Point(248, 40);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(52, 13);
            this.label41.TabIndex = 28;
            this.label41.Text = "(1-65535)";
            // 
            // txtAccessPointSimpleConnectMinutes
            // 
            this.txtAccessPointSimpleConnectMinutes.Location = new System.Drawing.Point(193, 33);
            this.txtAccessPointSimpleConnectMinutes.Name = "txtAccessPointSimpleConnectMinutes";
            this.txtAccessPointSimpleConnectMinutes.Size = new System.Drawing.Size(49, 20);
            this.txtAccessPointSimpleConnectMinutes.TabIndex = 26;
            this.txtAccessPointSimpleConnectMinutes.Text = "60";
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.Location = new System.Drawing.Point(190, 16);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(130, 13);
            this.label40.TabIndex = 27;
            this.label40.Text = "Wakeup Every X minutes:";
            // 
            // btnLoadAccessPointSchedulerData
            // 
            this.btnLoadAccessPointSchedulerData.Location = new System.Drawing.Point(19, 110);
            this.btnLoadAccessPointSchedulerData.Name = "btnLoadAccessPointSchedulerData";
            this.btnLoadAccessPointSchedulerData.Size = new System.Drawing.Size(162, 23);
            this.btnLoadAccessPointSchedulerData.TabIndex = 26;
            this.btnLoadAccessPointSchedulerData.Text = "Load Scheduler Settings";
            this.btnLoadAccessPointSchedulerData.UseVisualStyleBackColor = true;
            // 
            // cbAccessPointScheduler
            // 
            this.cbAccessPointScheduler.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAccessPointScheduler.FormattingEnabled = true;
            this.cbAccessPointScheduler.Location = new System.Drawing.Point(9, 32);
            this.cbAccessPointScheduler.Name = "cbAccessPointScheduler";
            this.cbAccessPointScheduler.Size = new System.Drawing.Size(146, 21);
            this.cbAccessPointScheduler.TabIndex = 26;
            this.cbAccessPointScheduler.SelectedIndexChanged += new System.EventHandler(this.cbAccessPointScheduler_SelectedIndexChanged);
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.Location = new System.Drawing.Point(6, 16);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(121, 13);
            this.label39.TabIndex = 26;
            this.label39.Text = "Choose Scheduler Type";
            // 
            // btnACGetNewLogsRepeat
            // 
            this.btnACGetNewLogsRepeat.Location = new System.Drawing.Point(608, 6);
            this.btnACGetNewLogsRepeat.Name = "btnACGetNewLogsRepeat";
            this.btnACGetNewLogsRepeat.Size = new System.Drawing.Size(148, 23);
            this.btnACGetNewLogsRepeat.TabIndex = 21;
            this.btnACGetNewLogsRepeat.Text = "getNewLogsUntilCurrent";
            this.btnACGetNewLogsRepeat.UseVisualStyleBackColor = true;
            this.btnACGetNewLogsRepeat.Click += new System.EventHandler(this.btnACGetNewLogsRepeat_Click);
            // 
            // btnSetAllLocksAccessPrimaryOnlyMode
            // 
            this.btnSetAllLocksAccessPrimaryOnlyMode.Location = new System.Drawing.Point(24, 296);
            this.btnSetAllLocksAccessPrimaryOnlyMode.Name = "btnSetAllLocksAccessPrimaryOnlyMode";
            this.btnSetAllLocksAccessPrimaryOnlyMode.Size = new System.Drawing.Size(234, 23);
            this.btnSetAllLocksAccessPrimaryOnlyMode.TabIndex = 20;
            this.btnSetAllLocksAccessPrimaryOnlyMode.Text = "Set All Locks Access Primary Only Mode";
            this.btnSetAllLocksAccessPrimaryOnlyMode.UseVisualStyleBackColor = true;
            this.btnSetAllLocksAccessPrimaryOnlyMode.Click += new System.EventHandler(this.btnSetAllLocksAccessPrimaryOnlyMode_Click);
            // 
            // grpAccessControlAccessPointOperations
            // 
            this.grpAccessControlAccessPointOperations.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpAccessControlAccessPointOperations.Controls.Add(this.label35);
            this.grpAccessControlAccessPointOperations.Controls.Add(this.txtUnlockTime);
            this.grpAccessControlAccessPointOperations.Controls.Add(this.btnSetUnlockTime);
            this.grpAccessControlAccessPointOperations.Controls.Add(this.label5);
            this.grpAccessControlAccessPointOperations.Controls.Add(this.label4);
            this.grpAccessControlAccessPointOperations.Controls.Add(this.btnRemoveAllAuthorizationsFromAccessPoint);
            this.grpAccessControlAccessPointOperations.Controls.Add(this.btnReset);
            this.grpAccessControlAccessPointOperations.Controls.Add(this.dpGetLogsByDateEndTime);
            this.grpAccessControlAccessPointOperations.Controls.Add(this.dpGetLogsByDateStartTime);
            this.grpAccessControlAccessPointOperations.Controls.Add(this.btnGetLogsByDate);
            this.grpAccessControlAccessPointOperations.Controls.Add(this.btnReloadAccessPointProvisioningData);
            this.grpAccessControlAccessPointOperations.Controls.Add(this.btnSetDateTime);
            this.grpAccessControlAccessPointOperations.Controls.Add(this.btnGetDateTime);
            this.grpAccessControlAccessPointOperations.Controls.Add(this.btnLock);
            this.grpAccessControlAccessPointOperations.Controls.Add(this.btnUnlock);
            this.grpAccessControlAccessPointOperations.Controls.Add(this.label3);
            this.grpAccessControlAccessPointOperations.Controls.Add(this.txtPulseTime);
            this.grpAccessControlAccessPointOperations.Controls.Add(this.btnPulseOpen);
            this.grpAccessControlAccessPointOperations.Location = new System.Drawing.Point(14, 35);
            this.grpAccessControlAccessPointOperations.Name = "grpAccessControlAccessPointOperations";
            this.grpAccessControlAccessPointOperations.Size = new System.Drawing.Size(521, 283);
            this.grpAccessControlAccessPointOperations.TabIndex = 7;
            this.grpAccessControlAccessPointOperations.TabStop = false;
            this.grpAccessControlAccessPointOperations.Text = "Operations";
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Location = new System.Drawing.Point(10, 165);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(116, 13);
            this.label35.TabIndex = 25;
            this.label35.Text = "Unlock Time (seconds)";
            // 
            // txtUnlockTime
            // 
            this.txtUnlockTime.Location = new System.Drawing.Point(13, 184);
            this.txtUnlockTime.Name = "txtUnlockTime";
            this.txtUnlockTime.Size = new System.Drawing.Size(37, 20);
            this.txtUnlockTime.TabIndex = 24;
            this.txtUnlockTime.Text = "5";
            // 
            // btnSetUnlockTime
            // 
            this.btnSetUnlockTime.Location = new System.Drawing.Point(56, 181);
            this.btnSetUnlockTime.Name = "btnSetUnlockTime";
            this.btnSetUnlockTime.Size = new System.Drawing.Size(102, 23);
            this.btnSetUnlockTime.TabIndex = 20;
            this.btnSetUnlockTime.Text = "Set Unlock Time";
            this.btnSetUnlockTime.UseVisualStyleBackColor = true;
            this.btnSetUnlockTime.Click += new System.EventHandler(this.btnSetUnlockTime_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(179, 54);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(97, 13);
            this.label5.TabIndex = 19;
            this.label5.Text = "Ending Date/Time:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 54);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Starting Date/Time:";
            // 
            // btnRemoveAllAuthorizationsFromAccessPoint
            // 
            this.btnRemoveAllAuthorizationsFromAccessPoint.Location = new System.Drawing.Point(10, 106);
            this.btnRemoveAllAuthorizationsFromAccessPoint.Name = "btnRemoveAllAuthorizationsFromAccessPoint";
            this.btnRemoveAllAuthorizationsFromAccessPoint.Size = new System.Drawing.Size(234, 23);
            this.btnRemoveAllAuthorizationsFromAccessPoint.TabIndex = 18;
            this.btnRemoveAllAuthorizationsFromAccessPoint.Text = "removeAllAuthorizationsFromAccessPoint";
            this.btnRemoveAllAuthorizationsFromAccessPoint.UseVisualStyleBackColor = true;
            this.btnRemoveAllAuthorizationsFromAccessPoint.Click += new System.EventHandler(this.btnRemoveAllAuthorizationsFromAccessPoint_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(250, 135);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 23);
            this.btnReset.TabIndex = 17;
            this.btnReset.Text = "reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // dpGetLogsByDateEndTime
            // 
            this.dpGetLogsByDateEndTime.CustomFormat = "M-d-yyyy hh:mm:ss tt";
            this.dpGetLogsByDateEndTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dpGetLogsByDateEndTime.Location = new System.Drawing.Point(182, 70);
            this.dpGetLogsByDateEndTime.Name = "dpGetLogsByDateEndTime";
            this.dpGetLogsByDateEndTime.Size = new System.Drawing.Size(160, 20);
            this.dpGetLogsByDateEndTime.TabIndex = 16;
            // 
            // dpGetLogsByDateStartTime
            // 
            this.dpGetLogsByDateStartTime.CustomFormat = "M-d-yyyy hh:mm:ss tt";
            this.dpGetLogsByDateStartTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dpGetLogsByDateStartTime.Location = new System.Drawing.Point(10, 70);
            this.dpGetLogsByDateStartTime.Name = "dpGetLogsByDateStartTime";
            this.dpGetLogsByDateStartTime.Size = new System.Drawing.Size(157, 20);
            this.dpGetLogsByDateStartTime.TabIndex = 15;
            this.dpGetLogsByDateStartTime.Value = new System.DateTime(2015, 10, 22, 2, 11, 0, 0);
            // 
            // btnGetLogsByDate
            // 
            this.btnGetLogsByDate.Location = new System.Drawing.Point(362, 67);
            this.btnGetLogsByDate.Name = "btnGetLogsByDate";
            this.btnGetLogsByDate.Size = new System.Drawing.Size(102, 23);
            this.btnGetLogsByDate.TabIndex = 14;
            this.btnGetLogsByDate.Text = "getLogsByDate";
            this.btnGetLogsByDate.UseVisualStyleBackColor = true;
            this.btnGetLogsByDate.Click += new System.EventHandler(this.btnGetLogsByDate_Click);
            // 
            // btnReloadAccessPointProvisioningData
            // 
            this.btnReloadAccessPointProvisioningData.Location = new System.Drawing.Point(10, 135);
            this.btnReloadAccessPointProvisioningData.Name = "btnReloadAccessPointProvisioningData";
            this.btnReloadAccessPointProvisioningData.Size = new System.Drawing.Size(234, 23);
            this.btnReloadAccessPointProvisioningData.TabIndex = 13;
            this.btnReloadAccessPointProvisioningData.Text = "reloadAccessPointProvisioningData";
            this.btnReloadAccessPointProvisioningData.UseVisualStyleBackColor = true;
            this.btnReloadAccessPointProvisioningData.Click += new System.EventHandler(this.btnReloadAccessPointProvisioningData_Click);
            // 
            // btnSetDateTime
            // 
            this.btnSetDateTime.Location = new System.Drawing.Point(431, 18);
            this.btnSetDateTime.Name = "btnSetDateTime";
            this.btnSetDateTime.Size = new System.Drawing.Size(84, 23);
            this.btnSetDateTime.TabIndex = 12;
            this.btnSetDateTime.Text = "setDateTime";
            this.btnSetDateTime.UseVisualStyleBackColor = true;
            this.btnSetDateTime.Click += new System.EventHandler(this.btnSetDateTime_Click);
            // 
            // btnGetDateTime
            // 
            this.btnGetDateTime.Location = new System.Drawing.Point(344, 19);
            this.btnGetDateTime.Name = "btnGetDateTime";
            this.btnGetDateTime.Size = new System.Drawing.Size(84, 23);
            this.btnGetDateTime.TabIndex = 11;
            this.btnGetDateTime.Text = "getDateTime";
            this.btnGetDateTime.UseVisualStyleBackColor = true;
            this.btnGetDateTime.Click += new System.EventHandler(this.btnGetDateTime_Click);
            // 
            // btnLock
            // 
            this.btnLock.Location = new System.Drawing.Point(263, 19);
            this.btnLock.Name = "btnLock";
            this.btnLock.Size = new System.Drawing.Size(75, 23);
            this.btnLock.TabIndex = 10;
            this.btnLock.Text = "lock";
            this.btnLock.UseVisualStyleBackColor = true;
            this.btnLock.Click += new System.EventHandler(this.btnLock_Click);
            // 
            // btnUnlock
            // 
            this.btnUnlock.Location = new System.Drawing.Point(182, 18);
            this.btnUnlock.Name = "btnUnlock";
            this.btnUnlock.Size = new System.Drawing.Size(75, 23);
            this.btnUnlock.TabIndex = 9;
            this.btnUnlock.Text = "unlock";
            this.btnUnlock.UseVisualStyleBackColor = true;
            this.btnUnlock.Click += new System.EventHandler(this.btnUnlock_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(147, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(20, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "ms";
            // 
            // txtPulseTime
            // 
            this.txtPulseTime.Location = new System.Drawing.Point(91, 21);
            this.txtPulseTime.MaxLength = 5;
            this.txtPulseTime.Name = "txtPulseTime";
            this.txtPulseTime.Size = new System.Drawing.Size(50, 20);
            this.txtPulseTime.TabIndex = 2;
            this.txtPulseTime.Text = "1000";
            this.txtPulseTime.WordWrap = false;
            // 
            // btnPulseOpen
            // 
            this.btnPulseOpen.Location = new System.Drawing.Point(10, 19);
            this.btnPulseOpen.Name = "btnPulseOpen";
            this.btnPulseOpen.Size = new System.Drawing.Size(75, 23);
            this.btnPulseOpen.TabIndex = 0;
            this.btnPulseOpen.Text = "pulseOpen";
            this.btnPulseOpen.UseVisualStyleBackColor = true;
            this.btnPulseOpen.Click += new System.EventHandler(this.btnPulseOpen_Click);
            // 
            // btnACGetNewLogs
            // 
            this.btnACGetNewLogs.Location = new System.Drawing.Point(423, 6);
            this.btnACGetNewLogs.Name = "btnACGetNewLogs";
            this.btnACGetNewLogs.Size = new System.Drawing.Size(166, 23);
            this.btnACGetNewLogs.TabIndex = 1;
            this.btnACGetNewLogs.Text = "getNewLogs (For Access Point)";
            this.btnACGetNewLogs.UseVisualStyleBackColor = true;
            this.btnACGetNewLogs.Click += new System.EventHandler(this.btnACGetNewLogs_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Select Access Point:";
            // 
            // cbAccessControlServiceAccessPoints
            // 
            this.cbAccessControlServiceAccessPoints.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAccessControlServiceAccessPoints.FormattingEnabled = true;
            this.cbAccessControlServiceAccessPoints.Location = new System.Drawing.Point(122, 6);
            this.cbAccessControlServiceAccessPoints.Name = "cbAccessControlServiceAccessPoints";
            this.cbAccessControlServiceAccessPoints.Size = new System.Drawing.Size(295, 21);
            this.cbAccessControlServiceAccessPoints.TabIndex = 5;
            this.cbAccessControlServiceAccessPoints.SelectedIndexChanged += new System.EventHandler(this.cbAccessControlServiceAccessPoints_SelectedIndexChanged);
            // 
            // tabPageAccessPointModes
            // 
            this.tabPageAccessPointModes.Controls.Add(this.cbAccessPointModeSchedulesList);
            this.tabPageAccessPointModes.Controls.Add(this.cbAccessPointModeType);
            this.tabPageAccessPointModes.Controls.Add(this.label25);
            this.tabPageAccessPointModes.Controls.Add(this.label24);
            this.tabPageAccessPointModes.Controls.Add(this.label23);
            this.tabPageAccessPointModes.Controls.Add(this.clbAccessPointModeAccessPointList);
            this.tabPageAccessPointModes.Controls.Add(this.btnModifyAccessPointMode);
            this.tabPageAccessPointModes.Controls.Add(this.btnRemoveAccessPointMode);
            this.tabPageAccessPointModes.Controls.Add(this.btnGetAccessPointModeIds);
            this.tabPageAccessPointModes.Controls.Add(this.cbAccessPointModeIdList);
            this.tabPageAccessPointModes.Controls.Add(this.btnAddAccessPointMode);
            this.tabPageAccessPointModes.Location = new System.Drawing.Point(4, 22);
            this.tabPageAccessPointModes.Name = "tabPageAccessPointModes";
            this.tabPageAccessPointModes.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageAccessPointModes.Size = new System.Drawing.Size(1021, 353);
            this.tabPageAccessPointModes.TabIndex = 7;
            this.tabPageAccessPointModes.Text = "Access Point Modes";
            this.tabPageAccessPointModes.UseVisualStyleBackColor = true;
            // 
            // cbAccessPointModeSchedulesList
            // 
            this.cbAccessPointModeSchedulesList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAccessPointModeSchedulesList.FormattingEnabled = true;
            this.cbAccessPointModeSchedulesList.Location = new System.Drawing.Point(10, 122);
            this.cbAccessPointModeSchedulesList.Name = "cbAccessPointModeSchedulesList";
            this.cbAccessPointModeSchedulesList.Size = new System.Drawing.Size(249, 21);
            this.cbAccessPointModeSchedulesList.TabIndex = 60;
            // 
            // cbAccessPointModeType
            // 
            this.cbAccessPointModeType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAccessPointModeType.FormattingEnabled = true;
            this.cbAccessPointModeType.Location = new System.Drawing.Point(10, 68);
            this.cbAccessPointModeType.Name = "cbAccessPointModeType";
            this.cbAccessPointModeType.Size = new System.Drawing.Size(249, 21);
            this.cbAccessPointModeType.TabIndex = 59;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(7, 52);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(126, 13);
            this.label25.TabIndex = 58;
            this.label25.Text = "Access Point Mode Type";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(303, 49);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(74, 13);
            this.label24.TabIndex = 57;
            this.label24.Text = "Access Points";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(7, 106);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(57, 13);
            this.label23.TabIndex = 56;
            this.label23.Text = "Schedules";
            // 
            // clbAccessPointModeAccessPointList
            // 
            this.clbAccessPointModeAccessPointList.FormattingEnabled = true;
            this.clbAccessPointModeAccessPointList.Location = new System.Drawing.Point(306, 68);
            this.clbAccessPointModeAccessPointList.Name = "clbAccessPointModeAccessPointList";
            this.clbAccessPointModeAccessPointList.Size = new System.Drawing.Size(373, 244);
            this.clbAccessPointModeAccessPointList.TabIndex = 55;
            // 
            // btnModifyAccessPointMode
            // 
            this.btnModifyAccessPointMode.Location = new System.Drawing.Point(596, 14);
            this.btnModifyAccessPointMode.Name = "btnModifyAccessPointMode";
            this.btnModifyAccessPointMode.Size = new System.Drawing.Size(151, 23);
            this.btnModifyAccessPointMode.TabIndex = 53;
            this.btnModifyAccessPointMode.Text = "modifyAccessPointMode";
            this.btnModifyAccessPointMode.UseVisualStyleBackColor = true;
            this.btnModifyAccessPointMode.Click += new System.EventHandler(this.btnModifyAccessPointMode_Click);
            // 
            // btnRemoveAccessPointMode
            // 
            this.btnRemoveAccessPointMode.Location = new System.Drawing.Point(753, 13);
            this.btnRemoveAccessPointMode.Name = "btnRemoveAccessPointMode";
            this.btnRemoveAccessPointMode.Size = new System.Drawing.Size(151, 23);
            this.btnRemoveAccessPointMode.TabIndex = 52;
            this.btnRemoveAccessPointMode.Text = "removeAccessPointMode";
            this.btnRemoveAccessPointMode.UseVisualStyleBackColor = true;
            this.btnRemoveAccessPointMode.Click += new System.EventHandler(this.btnRemoveAccessPointMode_Click);
            // 
            // btnGetAccessPointModeIds
            // 
            this.btnGetAccessPointModeIds.Location = new System.Drawing.Point(6, 15);
            this.btnGetAccessPointModeIds.Name = "btnGetAccessPointModeIds";
            this.btnGetAccessPointModeIds.Size = new System.Drawing.Size(152, 25);
            this.btnGetAccessPointModeIds.TabIndex = 49;
            this.btnGetAccessPointModeIds.Text = "getAccessPointModeIds";
            this.btnGetAccessPointModeIds.UseVisualStyleBackColor = true;
            this.btnGetAccessPointModeIds.Click += new System.EventHandler(this.btnGetAccessPointModeIds_Click);
            // 
            // cbAccessPointModeIdList
            // 
            this.cbAccessPointModeIdList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAccessPointModeIdList.FormattingEnabled = true;
            this.cbAccessPointModeIdList.Location = new System.Drawing.Point(175, 15);
            this.cbAccessPointModeIdList.Name = "cbAccessPointModeIdList";
            this.cbAccessPointModeIdList.Size = new System.Drawing.Size(249, 21);
            this.cbAccessPointModeIdList.TabIndex = 51;
            this.cbAccessPointModeIdList.SelectedIndexChanged += new System.EventHandler(this.cbAccessPointModeIdList_SelectedIndexChanged);
            // 
            // btnAddAccessPointMode
            // 
            this.btnAddAccessPointMode.Location = new System.Drawing.Point(439, 14);
            this.btnAddAccessPointMode.Name = "btnAddAccessPointMode";
            this.btnAddAccessPointMode.Size = new System.Drawing.Size(151, 23);
            this.btnAddAccessPointMode.TabIndex = 50;
            this.btnAddAccessPointMode.Text = "addAccessPointMode";
            this.btnAddAccessPointMode.UseVisualStyleBackColor = true;
            this.btnAddAccessPointMode.Click += new System.EventHandler(this.btnAddAccessPointMode_Click);
            // 
            // btnClearAll
            // 
            this.btnClearAll.Location = new System.Drawing.Point(164, 404);
            this.btnClearAll.Name = "btnClearAll";
            this.btnClearAll.Size = new System.Drawing.Size(148, 23);
            this.btnClearAll.TabIndex = 15;
            this.btnClearAll.Text = "clearAll";
            this.btnClearAll.UseVisualStyleBackColor = true;
            this.btnClearAll.Click += new System.EventHandler(this.btnClearAll_Click);
            // 
            // btnDeleteAllOrphanEntities
            // 
            this.btnDeleteAllOrphanEntities.Location = new System.Drawing.Point(10, 404);
            this.btnDeleteAllOrphanEntities.Name = "btnDeleteAllOrphanEntities";
            this.btnDeleteAllOrphanEntities.Size = new System.Drawing.Size(148, 23);
            this.btnDeleteAllOrphanEntities.TabIndex = 14;
            this.btnDeleteAllOrphanEntities.Text = "deleteAllOrphanEntities";
            this.btnDeleteAllOrphanEntities.UseVisualStyleBackColor = true;
            this.btnDeleteAllOrphanEntities.Click += new System.EventHandler(this.btnDeleteAllOrphanEntities_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageManagementService);
            this.tabControl1.Controls.Add(this.tabPageAccessControlService);
            this.tabControl1.Controls.Add(this.tabPageCallbackService);
            this.tabControl1.Controls.Add(this.tabPageSupportService);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1064, 471);
            this.tabControl1.TabIndex = 4;
            // 
            // tabPageManagementService
            // 
            this.tabPageManagementService.Controls.Add(this.groupBox1);
            this.tabPageManagementService.Location = new System.Drawing.Point(4, 22);
            this.tabPageManagementService.Name = "tabPageManagementService";
            this.tabPageManagementService.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageManagementService.Size = new System.Drawing.Size(1056, 445);
            this.tabPageManagementService.TabIndex = 0;
            this.tabPageManagementService.Text = "Management Service";
            this.tabPageManagementService.UseVisualStyleBackColor = true;
            // 
            // tabPageAccessControlService
            // 
            this.tabPageAccessControlService.Controls.Add(this.groupBox2);
            this.tabPageAccessControlService.Location = new System.Drawing.Point(4, 22);
            this.tabPageAccessControlService.Name = "tabPageAccessControlService";
            this.tabPageAccessControlService.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageAccessControlService.Size = new System.Drawing.Size(1056, 445);
            this.tabPageAccessControlService.TabIndex = 1;
            this.tabPageAccessControlService.Text = "Access Control Service";
            this.tabPageAccessControlService.UseVisualStyleBackColor = true;
            // 
            // tabPageCallbackService
            // 
            this.tabPageCallbackService.Controls.Add(this.eventTextBox);
            this.tabPageCallbackService.Location = new System.Drawing.Point(4, 22);
            this.tabPageCallbackService.Name = "tabPageCallbackService";
            this.tabPageCallbackService.Size = new System.Drawing.Size(1056, 445);
            this.tabPageCallbackService.TabIndex = 2;
            this.tabPageCallbackService.Text = "Callback Service";
            this.tabPageCallbackService.UseVisualStyleBackColor = true;
            // 
            // eventTextBox
            // 
            this.eventTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.eventTextBox.Location = new System.Drawing.Point(0, 0);
            this.eventTextBox.Name = "eventTextBox";
            this.eventTextBox.ReadOnly = true;
            this.eventTextBox.Size = new System.Drawing.Size(1056, 445);
            this.eventTextBox.TabIndex = 0;
            this.eventTextBox.Text = "";
            // 
            // tabPageSupportService
            // 
            this.tabPageSupportService.Location = new System.Drawing.Point(4, 22);
            this.tabPageSupportService.Name = "tabPageSupportService";
            this.tabPageSupportService.Size = new System.Drawing.Size(1056, 445);
            this.tabPageSupportService.TabIndex = 3;
            this.tabPageSupportService.Text = "Support Service";
            this.tabPageSupportService.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tabControl1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tabControl2);
            this.splitContainer1.Size = new System.Drawing.Size(1064, 692);
            this.splitContainer1.SplitterDistance = 471;
            this.splitContainer1.TabIndex = 5;
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.tabPageInformation);
            this.tabControl2.Controls.Add(this.tabPageErrors);
            this.tabControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl2.Location = new System.Drawing.Point(0, 0);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(1064, 217);
            this.tabControl2.TabIndex = 1;
            // 
            // tabPageInformation
            // 
            this.tabPageInformation.Controls.Add(this.txtInformation);
            this.tabPageInformation.Location = new System.Drawing.Point(4, 22);
            this.tabPageInformation.Name = "tabPageInformation";
            this.tabPageInformation.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageInformation.Size = new System.Drawing.Size(1056, 191);
            this.tabPageInformation.TabIndex = 0;
            this.tabPageInformation.Text = "Information";
            this.tabPageInformation.UseVisualStyleBackColor = true;
            // 
            // txtInformation
            // 
            this.txtInformation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtInformation.Location = new System.Drawing.Point(3, 3);
            this.txtInformation.Name = "txtInformation";
            this.txtInformation.ReadOnly = true;
            this.txtInformation.Size = new System.Drawing.Size(1050, 185);
            this.txtInformation.TabIndex = 0;
            this.txtInformation.Text = "";
            // 
            // tabPageErrors
            // 
            this.tabPageErrors.Controls.Add(this.txtErrors);
            this.tabPageErrors.Location = new System.Drawing.Point(4, 22);
            this.tabPageErrors.Name = "tabPageErrors";
            this.tabPageErrors.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageErrors.Size = new System.Drawing.Size(1056, 191);
            this.tabPageErrors.TabIndex = 1;
            this.tabPageErrors.Text = "Errors";
            this.tabPageErrors.UseVisualStyleBackColor = true;
            // 
            // txtErrors
            // 
            this.txtErrors.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtErrors.Location = new System.Drawing.Point(3, 3);
            this.txtErrors.Name = "txtErrors";
            this.txtErrors.ReadOnly = true;
            this.txtErrors.Size = new System.Drawing.Size(1050, 185);
            this.txtErrors.TabIndex = 1;
            this.txtErrors.Text = "";
            // 
            // btnFindUserByCardNumbers
            // 
            this.btnFindUserByCardNumbers.Location = new System.Drawing.Point(203, 180);
            this.btnFindUserByCardNumbers.Name = "btnFindUserByCardNumbers";
            this.btnFindUserByCardNumbers.Size = new System.Drawing.Size(75, 23);
            this.btnFindUserByCardNumbers.TabIndex = 67;
            this.btnFindUserByCardNumbers.Text = "Find User";
            this.btnFindUserByCardNumbers.UseVisualStyleBackColor = true;
            this.btnFindUserByCardNumbers.Click += new System.EventHandler(this.btnFindUserByCardNumbers_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1064, 692);
            this.Controls.Add(this.splitContainer1);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this.tabPageUsers.ResumeLayout(false);
            this.tabPageUsers.PerformLayout();
            this.tabPageDayPeriods.ResumeLayout(false);
            this.tabPageDayPeriods.PerformLayout();
            this.tabPageDayExceptions.ResumeLayout(false);
            this.tabPageDayExceptions.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.tabPageSchedules.ResumeLayout(false);
            this.tabPageSchedules.PerformLayout();
            this.tabPageAuthorizations.ResumeLayout(false);
            this.tabPageAuthorizations.PerformLayout();
            this.tabPageAccessPointSpecificOperations.ResumeLayout(false);
            this.tabPageAccessPointSpecificOperations.PerformLayout();
            this.tabControl3.ResumeLayout(false);
            this.tabPageAlarms.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.tabPageScheduler.ResumeLayout(false);
            this.tabPageScheduler.PerformLayout();
            this.grpAccessControlAccessPointOperations.ResumeLayout(false);
            this.grpAccessControlAccessPointOperations.PerformLayout();
            this.tabPageAccessPointModes.ResumeLayout(false);
            this.tabPageAccessPointModes.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPageManagementService.ResumeLayout(false);
            this.tabPageAccessControlService.ResumeLayout(false);
            this.tabPageCallbackService.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tabControl2.ResumeLayout(false);
            this.tabPageInformation.ResumeLayout(false);
            this.tabPageErrors.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnListAccessPoints;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnListAllAccessPoints;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnACGetNewLogs;
        private System.Windows.Forms.Button btnGetAccessPointTypes;
        private System.Windows.Forms.ComboBox cbAllAccessPoints;
        private System.Windows.Forms.ComboBox cbAccessPointTypes;
        private System.Windows.Forms.ComboBox cbAccessPointsByType;
        private System.Windows.Forms.Button btnListAccessPointsOnline;
        private System.Windows.Forms.ComboBox cbAccessPointsOnline;
        private System.Windows.Forms.Button btnGetAccessPointStatus;
        private System.Windows.Forms.Button btnFindAccessPointBySerialNumber;
        private System.Windows.Forms.Button btnVerifyAccessPointOnline;
        private System.Windows.Forms.Button btnConfirmAccessPoint;
        private System.Windows.Forms.Button btnAddAndConfirmAccessPoint;
        private System.Windows.Forms.Button btnRegisterCallback;
        private System.Windows.Forms.Button btnListCallbackEndpoints;
        private System.Windows.Forms.Button btnUnregisterCallback;
        private System.Windows.Forms.Button btnGetSupportedCredentialFormats;
        private System.Windows.Forms.Button btnGetVersionInfo;
        private System.Windows.Forms.Button btnGetStatus;
        private System.Windows.Forms.Button btnSetAccessPointEndpointParams;
        private System.Windows.Forms.Button btnEnableAccessPoint;
        private System.Windows.Forms.Button btnDisableAccessPoint;
        private System.Windows.Forms.Button btnReplaceAccessPoint;
        private System.Windows.Forms.Button btnClearAccessPoint;
        private System.Windows.Forms.Button btnRemoveAccessPoint;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageManagementService;
        private System.Windows.Forms.TabPage tabPageAccessControlService;
        private System.Windows.Forms.TabPage tabPageCallbackService;
        private System.Windows.Forms.TabPage tabPageSupportService;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.RichTextBox txtInformation;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tabPageInformation;
        private System.Windows.Forms.TabPage tabPageErrors;
        private System.Windows.Forms.RichTextBox txtErrors;
        private System.Windows.Forms.RichTextBox eventTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtAddAccessPointSerialNumber;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbAccessControlServiceAccessPoints;
        private System.Windows.Forms.GroupBox grpAccessControlAccessPointOperations;
        private System.Windows.Forms.Button btnPulseOpen;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPulseTime;
        private System.Windows.Forms.Button btnLock;
        private System.Windows.Forms.Button btnUnlock;
        private System.Windows.Forms.Button btnSetDateTime;
        private System.Windows.Forms.Button btnGetDateTime;
        private System.Windows.Forms.Button btnReloadAccessPointProvisioningData;
        private System.Windows.Forms.Button btnGetLogsByDate;
        private System.Windows.Forms.DateTimePicker dpGetLogsByDateStartTime;
        private System.Windows.Forms.DateTimePicker dpGetLogsByDateEndTime;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnRemoveAllAuthorizationsFromAccessPoint;
        private System.Windows.Forms.Button btnDeleteAllOrphanEntities;
        private System.Windows.Forms.Button btnClearAll;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPageUsers;
        private System.Windows.Forms.Button btnAddUser;
        private System.Windows.Forms.TabPage tabPageDayPeriods;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dtpUserValidUntil;
        private System.Windows.Forms.DateTimePicker dtpUserValidFrom;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chkUserSuspended;
        private System.Windows.Forms.CheckBox chkUserExtended;
        private System.Windows.Forms.Button btnGetUserIds;
        private System.Windows.Forms.Button btnRemoveUser;
        private System.Windows.Forms.Button btnModifyUser;
        private System.Windows.Forms.Button btnRemoveUserCascading;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cbCredentialFormats;
        private System.Windows.Forms.TextBox txtCredentialIntegerValue;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtCredentialFacilityCode;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TabPage tabPageAuthorizations;
        private System.Windows.Forms.Button btnAuthorizeAllUsersAllLocks;
        private System.Windows.Forms.ComboBox cbUserIds;
        private System.Windows.Forms.Button btnSetAllLocksAccessPrimaryOnlyMode;
        private System.Windows.Forms.Button btnGetDayPeriodIds;
        private System.Windows.Forms.Button btnAddDayPeriod;
        private System.Windows.Forms.CheckedListBox WeekDayCheckBoxList;
        private System.Windows.Forms.ComboBox cbDayPeriodIdList;
        private System.Windows.Forms.DateTimePicker dayPeriodEndTime;
        private System.Windows.Forms.DateTimePicker dayPeriodStartTime;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button btnRemoveDayPeriod;
        private System.Windows.Forms.Button btnModifyDayPeriod;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtDSRIpAddress;
        private System.Windows.Forms.TabPage tabPageSchedules;
        private System.Windows.Forms.Button btnModifySchedule;
        private System.Windows.Forms.Button btnRemoveSchedule;
        private System.Windows.Forms.ComboBox cbScheduleIdList;
        private System.Windows.Forms.Button btnAddSchedule;
        private System.Windows.Forms.Button btnGetScheduleIds;
        private System.Windows.Forms.CheckedListBox clbScheduleDayPeriodCheckedListBox;
        private System.Windows.Forms.TabPage tabPageDayExceptions;
        private System.Windows.Forms.Button btnModifyDayException;
        private System.Windows.Forms.Button btnRemoveDayException;
        private System.Windows.Forms.ComboBox cbDayExceptionIdList;
        private System.Windows.Forms.Button btnAddDayException;
        private System.Windows.Forms.Button btnGetDayExceptionIds;
        private System.Windows.Forms.TabPage tabPageAccessPointSpecificOperations;
        private System.Windows.Forms.DateTimePicker dtpDayExceptionEndTime;
        private System.Windows.Forms.DateTimePicker dtpDayExceptionStartTime;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.DateTimePicker dtpDayExceptionDate;
        private System.Windows.Forms.Button btnDayExceptionAddTimePeriod;
        private System.Windows.Forms.CheckedListBox clbDayExceptionTimePeriods;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckedListBox clbDayExceptionGroupsDayExceptionIdList;
        private System.Windows.Forms.Button btnModifyDayExceptionGroup;
        private System.Windows.Forms.Button btnRemoveDayExceptionGroup;
        private System.Windows.Forms.Button btnGetDayExceptionGroupIds;
        private System.Windows.Forms.ComboBox cbDayExceptionGroupIdList;
        private System.Windows.Forms.Button btnAddDayExceptionGroup;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.CheckedListBox clbScheduleDayExceptionGroupIdList;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Button btnDayPeriodAddTimePeriod;
        private System.Windows.Forms.CheckedListBox clbDayPeriodTimePeriods;
        private DayPeriodViewControl scheduleDayPeriodViewControl;
        private ucDayExceptionViewControl ucDayExceptionViewControl;
        private System.Windows.Forms.ListBox lbScheduleDayExceptionGroupDayExceptions;
        private System.Windows.Forms.Label label22;
        private ucDayExceptionViewControl ucScheduleDayExceptionViewControl;
        private System.Windows.Forms.TabPage tabPageAccessPointModes;
        private System.Windows.Forms.Button btnModifyAccessPointMode;
        private System.Windows.Forms.Button btnRemoveAccessPointMode;
        private System.Windows.Forms.Button btnGetAccessPointModeIds;
        private System.Windows.Forms.ComboBox cbAccessPointModeIdList;
        private System.Windows.Forms.Button btnAddAccessPointMode;
        private System.Windows.Forms.ComboBox cbAccessPointModeType;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.CheckedListBox clbAccessPointModeAccessPointList;
        private System.Windows.Forms.ComboBox cbAccessPointModeSchedulesList;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.CheckedListBox clbUserAuthorizeAccessPoints;
        private System.Windows.Forms.Button btnModifyAuthorization;
        private System.Windows.Forms.Button btnRemoveAuthorization;
        private System.Windows.Forms.ComboBox cbAuthorizationIdList;
        private System.Windows.Forms.Button btnAddAuthorization;
        private System.Windows.Forms.Button btnGetAuthorizationIds;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.ComboBox cbUserAuthorizationSchedule;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cbUserAuthorizationType;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.ComboBox cbAuthorizationAuthorizationSchedule;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.ComboBox cbAuthorizationAuthorizationType;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.CheckedListBox clbAuthorizationAuthorizeUsers;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.CheckedListBox clbAuthorizationAuthorizeAccessPoints;
        private System.Windows.Forms.TextBox txtAccessPointDescription;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.Button btnAddReaderDescription;
        private System.Windows.Forms.Button btnRemoveDayExceptionFromDayExceptionGroup;
        private System.Windows.Forms.Button btnAddDayExceptionToDayExceptionGroup;
        private System.Windows.Forms.Button btnRemoveDayExceptionGroupFromSchedule;
        private System.Windows.Forms.Button btnAddDayExceptionGroupToSchedule;
        private System.Windows.Forms.Button btnRemoveDayPeriodFromSchedule;
        private System.Windows.Forms.Button btnAddDayPeriodToSchedule;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.TextBox txtCallbackAddress;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.TextBox txtCallbackPort;
        private System.Windows.Forms.Button btnACGetNewLogsRepeat;
        private System.Windows.Forms.Button btnSetAuthorizationTypeForAuthorization;
        private System.Windows.Forms.Button btnSetNewScheduleInAuthorization;
        private System.Windows.Forms.Button btnremoveAccessPointsFromAuthorization;
        private System.Windows.Forms.Button btnaddAccessPointsToAuthorization;
        private System.Windows.Forms.Button btnremoveUsersFromAuthorization;
        private System.Windows.Forms.Button btnaddUsersToAuthorization;
        private System.Windows.Forms.Button btnSetUnlockTime;
        private System.Windows.Forms.Button btnSetFilters;
        private System.Windows.Forms.Button btnSetAlarms;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.TextBox txtUnlockTime;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.CheckedListBox clbRXHeldModeAlarms;
        private System.Windows.Forms.CheckedListBox clbPassageModeAlarms;
        private System.Windows.Forms.CheckedListBox clbSecuredModeAlarms;
        private System.Windows.Forms.Label label38;
        private System.Windows.Forms.TabControl tabControl3;
        private System.Windows.Forms.TabPage tabPageAlarms;
        private System.Windows.Forms.TabPage tabPageFilters;
        private System.Windows.Forms.TabPage tabPageScheduler;
        private System.Windows.Forms.Button btnLoadAccessPointSchedulerData;
        private System.Windows.Forms.ComboBox cbAccessPointScheduler;
        private System.Windows.Forms.Label label39;
        private System.Windows.Forms.Button btnSetAccessPointSchedulerSimple;
        private System.Windows.Forms.Label label41;
        private System.Windows.Forms.TextBox txtAccessPointSimpleConnectMinutes;
        private System.Windows.Forms.Label label40;
        private System.Windows.Forms.TextBox txtCredentialPINStringValue;
        private System.Windows.Forms.Label label42;
        private System.Windows.Forms.TextBox txtCredentialStringValue;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnACGetNewLogsRepeatForDSR;
        private System.Windows.Forms.Label label43;
        private System.Windows.Forms.TextBox txtUseCount;
        private System.Windows.Forms.Label lblUserCount;
        private System.Windows.Forms.Label lblAccessPointCount;
        private System.Windows.Forms.Label label44;
        private System.Windows.Forms.Button btnToggleAllAccessPointsAuthorization;
        private System.Windows.Forms.Button btnToggleAllUsersAuthorization;
        private System.Windows.Forms.TextBox txtToggleAuthIncCount;
        private System.Windows.Forms.Button btnRemoveAllAccessPoints;
        private System.Windows.Forms.CheckBox chkUseEncryption;
        private System.Windows.Forms.Button btnFindUserByCardNumbers;
    }
}

