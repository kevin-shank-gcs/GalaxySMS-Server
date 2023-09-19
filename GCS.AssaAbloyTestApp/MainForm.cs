using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using GCS.AssaAbloyDSR;
using GCS.AssaAbloyDSR.DSRAccessControlService;
using GCS.AssaAbloyDSR.DSRManagementService;
using CredentialFormat = GCS.AssaAbloyDSR.DSRAccessControlService.CredentialFormat;

namespace GCS.AssaAbloyTestApp
{
    public partial class MainForm : Form
    {
        private static RichTextBox callbackText;
        private readonly string _addressHeaderNamespace = "http://www.w3.org/2005/08/addressing";
        private DsrAccessControlProxy _dsrAccessControlProxy;
        private DsrManagementProxy _dsrManagementProxy;
        private string callbackUrl = "http://192.168.19.10:9091/callback";

        private IEnumerable<GCS.AssaAbloyDSR.DSRManagementService.AccessPoint> AccessPoints;
        private IEnumerable<GCS.AssaAbloyDSR.DSRManagementService.AccessPointType> AccessPointTypes;
        private GCS.AssaAbloyDSR.DSRManagementService.AccessPoint SelectedAccessControlTabAccessPoint;
        private GCS.AssaAbloyDSR.DSRManagementService.AccessPointType SelectedAccessPointType;
        private GCS.AssaAbloyDSR.DSRManagementService.AccessPoint SelectedManagementTabAccessPoint;
        private DsrConnectionParameters dsrConnectionParameters;
        private DayExceptionGroup _selectedDayExceptionGroup;
        private Schedule _selectedSchedule;

        public MainForm()
        {
            InitializeComponent();

            this.txtDSRIpAddress.Text = Properties.Settings.Default.DSRIPAddress;// "63.122.126.103";
            this.txtCallbackAddress.Text = Properties.Settings.Default.CallbackAddress;
            this.txtCallbackPort.Text = Properties.Settings.Default.CallbackPort;
            this.chkUseEncryption.Checked = Properties.Settings.Default.UseHttps;

            CreateDsrConnectionParameters();

            _dsrManagementProxy = new DsrManagementProxy(dsrConnectionParameters);
            _dsrAccessControlProxy = new DsrAccessControlProxy(dsrConnectionParameters);
            callbackText = eventTextBox;
            var credentialFormats = Enum.GetValues(typeof(CredentialFormat)).Cast<CredentialFormat>();
            foreach (var format in credentialFormats)
                cbCredentialFormats.Items.Add(format);

            cbCredentialFormats.SelectedItem = CredentialFormat.PIN_CODE;
            WeekDayCheckBoxList.Items.Add(WeekDay.SUNDAY);
            WeekDayCheckBoxList.Items.Add(WeekDay.MONDAY);
            WeekDayCheckBoxList.Items.Add(WeekDay.TUESDAY);
            WeekDayCheckBoxList.Items.Add(WeekDay.WEDNESDAY);
            WeekDayCheckBoxList.Items.Add(WeekDay.THURSDAY);
            WeekDayCheckBoxList.Items.Add(WeekDay.FRIDAY);
            WeekDayCheckBoxList.Items.Add(WeekDay.SATURDAY);

            cbAccessPointModeType.Items.Add(AccessPointModeType.ACCESSMODE_PRIMARY);
            cbAccessPointModeType.Items.Add(AccessPointModeType.ACCESSMODE_PRIMARY_AND_SECONDARY);
            cbAccessPointModeType.Items.Add(AccessPointModeType.ACCESSMODE_PRIMARY_OR_SECONDARY);
            cbAccessPointModeType.Items.Add(AccessPointModeType.ACCESSMODE_PRIMARY_THEN_SECONDARY);
            cbAccessPointModeType.Items.Add(AccessPointModeType.FIRST_PERSON_THROUGH);
            cbAccessPointModeType.Items.Add(AccessPointModeType.UNLOCK);

            cbAccessPointModeType.SelectedItem = AccessPointModeType.ACCESSMODE_PRIMARY;

            cbUserAuthorizationType.Items.Add(AuthorizationType.ACCESS);
            cbUserAuthorizationType.Items.Add(AuthorizationType.LOCK);
            cbUserAuthorizationType.Items.Add(AuthorizationType.UNLOCK);
            cbUserAuthorizationType.Items.Add(AuthorizationType.WAKEUP);
            cbUserAuthorizationType.Items.Add(AuthorizationType.ACCESS_OVERRIDE_DEADBOLT);
            cbUserAuthorizationType.Items.Add(AuthorizationType.LIMITED_USE);
            cbUserAuthorizationType.Items.Add(AuthorizationType.UAPM);

            cbUserAuthorizationType.SelectedItem = AuthorizationType.ACCESS;

            cbAuthorizationAuthorizationType.Items.Add(AuthorizationType.ACCESS);
            cbAuthorizationAuthorizationType.Items.Add(AuthorizationType.LOCK);
            cbAuthorizationAuthorizationType.Items.Add(AuthorizationType.UNLOCK);
            cbAuthorizationAuthorizationType.Items.Add(AuthorizationType.WAKEUP);
            cbAuthorizationAuthorizationType.Items.Add(AuthorizationType.ACCESS_OVERRIDE_DEADBOLT);
            cbAuthorizationAuthorizationType.Items.Add(AuthorizationType.LIMITED_USE);
            cbAuthorizationAuthorizationType.Items.Add(AuthorizationType.UAPM);

            cbAuthorizationAuthorizationType.SelectedItem = AuthorizationType.ACCESS;

            clbAccessPointModeAccessPointList.DisplayMember = "SerialNumber";
            clbUserAuthorizeAccessPoints.DisplayMember = "SerialNumber";
            clbAuthorizationAuthorizeAccessPoints.DisplayMember = "SerialNumber";

            FillAlarmsCheckListBox(ref clbSecuredModeAlarms, Alarms.AlarmMode.SecuredMode);
            FillAlarmsCheckListBox(ref clbPassageModeAlarms, Alarms.AlarmMode.PassageMode);
            FillAlarmsCheckListBox(ref clbRXHeldModeAlarms, Alarms.AlarmMode.RXHeldMode);

            this.cbAccessPointScheduler.Items.Add(new SchedulingAlgorithm(SchedulingAlgorithm.ScheduleType.Simple));
            this.cbAccessPointScheduler.Items.Add(new SchedulingAlgorithm(SchedulingAlgorithm.ScheduleType.AlwaysOff));
            this.cbAccessPointScheduler.Items.Add(new SchedulingAlgorithm(SchedulingAlgorithm.ScheduleType.AlwaysOn));
            this.cbAccessPointScheduler.Items.Add(new SchedulingAlgorithm(SchedulingAlgorithm.ScheduleType.CommUser));
            this.cbAccessPointScheduler.Items.Add(new SchedulingAlgorithm(SchedulingAlgorithm.ScheduleType.DayOfMonth));
            this.cbAccessPointScheduler.Items.Add(new SchedulingAlgorithm(SchedulingAlgorithm.ScheduleType.DayOfWeek));
            this.cbAccessPointScheduler.Items.Add(new SchedulingAlgorithm(SchedulingAlgorithm.ScheduleType.HourOfDay));
            cbAccessPointScheduler.SelectedIndex = 0;
        }

        private void CreateDsrConnectionParameters()
        {
            UnregisterCallbackUrl(callbackUrl);

            if (chkUseEncryption.Checked == false)
            {
                callbackUrl = string.Format("http://{0}:{1}/callback",
                    this.txtCallbackAddress.Text,
                    this.txtCallbackPort.Text);
            }
            else
            {
                callbackUrl = string.Format("https://{0}:{1}/callback",
                    this.txtCallbackAddress.Text,
                    this.txtCallbackPort.Text);
            }

            dsrConnectionParameters = new DsrConnectionParameters()
            {
                IpAddress = txtDSRIpAddress.Text,
                Port = 8080,
                UseHttps = this.chkUseEncryption.Checked
            };

            _dsrManagementProxy = new DsrManagementProxy(dsrConnectionParameters);
            _dsrAccessControlProxy = new DsrAccessControlProxy(dsrConnectionParameters);
        }

        private void FillAlarmsCheckListBox(ref CheckedListBox clb, Alarms.AlarmMode mode)
        {
            clb.Items.Clear();
            clb.Items.Add(new Alarm(mode, Alarms.AlarmType.None));
            clb.Items.Add(new Alarm(mode, Alarms.AlarmType.Valid));
            clb.Items.Add(new Alarm(mode, Alarms.AlarmType.Denied));
            clb.Items.Add(new Alarm(mode, Alarms.AlarmType.DoorSecured));
            clb.Items.Add(new Alarm(mode, Alarms.AlarmType.DoorForced));
            clb.Items.Add(new Alarm(mode, Alarms.AlarmType.KeyOverride));
            clb.Items.Add(new Alarm(mode, Alarms.AlarmType.InvalidEntry));
            clb.Items.Add(new Alarm(mode, Alarms.AlarmType.DoorAjar));
            clb.Items.Add(new Alarm(mode, Alarms.AlarmType.LowBattery));
            clb.Items.Add(new Alarm(mode, Alarms.AlarmType.RXHeld));
        }

        #region Access Control Service Operations

        private async void btnACGetNewLogs_Click(object sender, EventArgs e)
        {
            var methodName = DsrAccessControlServiceMethodNames.GetNewLogs;
            try
            {
                if (SelectedAccessControlTabAccessPoint != null)
                {
                    var data = await _dsrAccessControlProxy.GetNewLogsAsync(SelectedAccessControlTabAccessPoint.id);
                    if (data != null)
                    {
                        var sb = new StringBuilder();
                        sb.Append(methodName);
                        foreach (var logEntry in data)
                        {
                            sb.Append(
                                string.Format(
                                    "\n\tTimeStamp:{0}, Code:{1}, Family:{2}, origin.logOriginType:{3}, origin.originId:{4}, requestId:{5}",
                                    logEntry.timeStamp,
                                    logEntry.code,
                                    logEntry.family,
                                    logEntry.origin.logOriginType,
                                    logEntry.origin.originId,
                                    logEntry.requestId.requestId));
                            foreach (var log in logEntry.logData)
                            {
                                sb.Append(
                                    string.Format(
                                        "\n\t\tName:{0}, stringValue:{1}, intValueSpecified:{2}, intValue:{3}",
                                        log.name,
                                        log.value.stringValue,
                                        log.value.intValueSpecified,
                                        log.value.intValue));
                            }
                        }
                        LogInformation(sb.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                Log(methodName, ex);
            }
        }

        #endregion

        private void txtAddAccessPointSerialNumber_TextChanged(object sender, EventArgs e)
        {
            btnAddAndConfirmAccessPoint.Enabled = !string.IsNullOrEmpty(txtAddAccessPointSerialNumber.Text) &&
                                                  SelectedAccessPointType != null;
        }

        private void cbAccessControlServiceAccessPoints_SelectedIndexChanged(object sender, EventArgs e)
        {
            var ap =
                cbAccessControlServiceAccessPoints.SelectedItem as GCS.AssaAbloyDSR.DSRManagementService.AccessPoint;
            SetSelectedAccessControlAccessPoint(ap);
        }

        private async void btnPulseOpen_Click(object sender, EventArgs e)
        {
            var methodName = DsrAccessControlServiceMethodNames.PulseOpen;
            try
            {
                if (SelectedAccessControlTabAccessPoint != null)
                {
                    long pulseTime = 1000;
                    if (!long.TryParse(txtPulseTime.Text, out pulseTime))
                        return;
                    var data =
                        await _dsrAccessControlProxy.PulseOpenAsync(SelectedAccessControlTabAccessPoint.id, pulseTime);
                    if (data != null)
                    {
                        var sb = new StringBuilder();
                        sb.Append(methodName);
                        LogInformation(sb.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                Log(methodName, ex);
            }
        }

        private async void btnUnlock_Click(object sender, EventArgs e)
        {
            var methodName = DsrAccessControlServiceMethodNames.Unlock;
            try
            {
                if (SelectedAccessControlTabAccessPoint != null)
                {
                    var data =
                        await _dsrAccessControlProxy.UnlockAsync(SelectedAccessControlTabAccessPoint.id);
                    if (data != null)
                    {
                        var sb = new StringBuilder();
                        sb.Append(methodName);
                        LogInformation(sb.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                Log(methodName, ex);
            }
        }

        private async void btnLock_Click(object sender, EventArgs e)
        {
            var methodName = DsrAccessControlServiceMethodNames.Lock;
            try
            {
                if (SelectedAccessControlTabAccessPoint != null)
                {
                    var data =
                        await _dsrAccessControlProxy.LockAsync(SelectedAccessControlTabAccessPoint.id);
                    if (data != null)
                    {
                        var sb = new StringBuilder();
                        sb.Append(methodName);
                        LogInformation(sb.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                Log(methodName, ex);
            }
        }

        private async void btnGetDateTime_Click(object sender, EventArgs e)
        {
            var methodName = DsrAccessControlServiceMethodNames.GetDateTime;
            try
            {
                if (SelectedAccessControlTabAccessPoint != null)
                {
                    var data =
                        await _dsrAccessControlProxy.GetDateTimeAsync(SelectedAccessControlTabAccessPoint.id);
                    var sb = new StringBuilder();
                    sb.Append(methodName);
                    sb.Append(string.Format("\n\t{0}", data));
                    LogInformation(sb.ToString());
                }
            }
            catch (Exception ex)
            {
                Log(methodName, ex);
            }
        }

        private async void btnSetDateTime_Click(object sender, EventArgs e)
        {
            var methodName = DsrAccessControlServiceMethodNames.SetDateTime;
            try
            {
                if (SelectedAccessControlTabAccessPoint != null)
                {
                    var data =
                        await
                            _dsrAccessControlProxy.SetDateTimeAsync(SelectedAccessControlTabAccessPoint.id, DateTime.Now);
                    if (data != null)
                    {
                        var sb = new StringBuilder();
                        sb.Append(methodName);
                        LogInformation(sb.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                Log(methodName, ex);
            }
        }

        private async void btnReloadAccessPointProvisioningData_Click(object sender, EventArgs e)
        {
            var methodName = DsrAccessControlServiceMethodNames.ReloadAccessPointProvisioningData;
            try
            {
                if (SelectedAccessControlTabAccessPoint != null)
                {
                    var data =
                        await
                            _dsrAccessControlProxy.ReloadAccessPointProvisioningDataAsync(
                                SelectedAccessControlTabAccessPoint.id, null);
                    if (data != null)
                    {
                        var sb = new StringBuilder();
                        sb.Append(methodName);
                        LogInformation(sb.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                Log(methodName, ex);
            }
        }

        private async void btnGetLogsByDate_Click(object sender, EventArgs e)
        {
            var methodName = DsrAccessControlServiceMethodNames.GetLogsByDate;
            try
            {
                if (SelectedAccessControlTabAccessPoint != null)
                {
                    if (dpGetLogsByDateStartTime.Value >= dpGetLogsByDateEndTime.Value)
                    {
                        MessageBox.Show("End date must be after the Start date", "Invalid Dates",
                            MessageBoxButtons.OK);
                        return;
                    }
                    var data =
                        await
                            _dsrAccessControlProxy.GetLogsByDateAsync(SelectedAccessControlTabAccessPoint.id,
                                dpGetLogsByDateStartTime.Value, dpGetLogsByDateEndTime.Value);
                    if (data != null)
                    {
                        var sb = new StringBuilder();
                        sb.Append(methodName);
                        foreach (var logEntry in data)
                        {
                            sb.Append(
                                string.Format(
                                    "\n\tTimeStamp:{0}, Code:{1}, Family:{2}, origin.logOriginType:{3}, origin.originId:{4}, requestId:{5}",
                                    logEntry.timeStamp,
                                    logEntry.code,
                                    logEntry.family,
                                    logEntry.origin.logOriginType,
                                    logEntry.origin.originId,
                                    logEntry.requestId.requestId));
                            foreach (var log in logEntry.logData)
                            {
                                sb.Append(
                                    string.Format(
                                        "\n\t\tName:{0}, stringValue:{1}, intValueSpecified:{2}, intValue:{3}",
                                        log.name,
                                        log.value.stringValue,
                                        log.value.intValueSpecified,
                                        log.value.intValue));
                            }
                        }
                        LogInformation(sb.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                Log(methodName, ex);
            }
        }

        private async void btnReset_Click(object sender, EventArgs e)
        {
            var methodName = DsrAccessControlServiceMethodNames.Reset;
            try
            {
                if (SelectedAccessControlTabAccessPoint != null)
                {
                    if (MessageBox.Show("Are You Sure?", "Confirm", MessageBoxButtons.YesNo) != DialogResult.Yes)
                        return;
                    var data = await _dsrAccessControlProxy.ResetAsync(SelectedAccessControlTabAccessPoint.id);
                    if (data != null)
                    {
                        var sb = new StringBuilder();
                        sb.Append(methodName);
                        LogInformation(sb.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                Log(methodName, ex);
            }
        }

        private async void btnRemoveAllAuthorizationsFromAccessPoint_Click(object sender, EventArgs e)
        {
            var methodName = DsrAccessControlServiceMethodNames.RemoveAllAuthorizationsFromAccessPoint;
            try
            {
                if (SelectedAccessControlTabAccessPoint != null)
                {
                    if (MessageBox.Show("Are You Sure?", "Confirm", MessageBoxButtons.YesNo) != DialogResult.Yes)
                        return;
                    var data =
                        await
                            _dsrAccessControlProxy.RemoveAllAuthorizationsFromAccessPointAsync(
                                SelectedAccessControlTabAccessPoint.id, null);

                    var sb = new StringBuilder();
                    sb.Append(methodName);
                    if (data != null)
                    {
                        foreach (var result in data)
                        {
                            sb.Append(string.Format("\n\t{0}", result));
                        }
                    }
                    LogInformation(sb.ToString());
                }
            }
            catch (Exception ex)
            {
                Log(methodName, ex);
            }
        }

        private async void btnDeleteAllOrphanEntities_Click(object sender, EventArgs e)
        {
            var methodName = DsrAccessControlServiceMethodNames.DeleteAllOrphanEntities;
            try
            {
                if (MessageBox.Show("Are You Sure?", "Confirm", MessageBoxButtons.YesNo) != DialogResult.Yes)
                    return;

                var uuid = _dsrAccessControlProxy.CreateAccessControlServiceDsrUuid();
                var data =
                    await
                        _dsrAccessControlProxy.DeleteAllOrphanEntitiesAsync(uuid);
                if (data != null)
                {
                    var sb = new StringBuilder();
                    sb.Append(methodName);
                    if (data != null)
                    {
                        foreach (var result in data)
                        {
                            sb.Append(string.Format("\n\t{0}", result));
                        }
                    }
                    LogInformation(sb.ToString());
                }
            }
            catch (Exception ex)
            {
                Log(methodName, ex);
            }
        }

        private async void btnClearAll_Click(object sender, EventArgs e)
        {
            var methodName = DsrAccessControlServiceMethodNames.ClearAll;
            try
            {
                if (MessageBox.Show("Are You Sure?", "Confirm", MessageBoxButtons.YesNo) != DialogResult.Yes)
                    return;
                var uuid = _dsrAccessControlProxy.CreateAccessControlServiceDsrUuid();
                var data =
                    await
                        _dsrAccessControlProxy.ClearAllAsync(uuid);
                if (data != null)
                {
                    var sb = new StringBuilder();
                    sb.Append(methodName);
                    LogInformation(sb.ToString());
                }
            }
            catch (Exception ex)
            {
                Log(methodName, ex);
            }
        }

        private async void btnAddUser_Click(object sender, EventArgs e)
        {
            var methodName = DsrAccessControlServiceMethodNames.AddUser;
            try
            {
                var uuid = _dsrAccessControlProxy.CreateAccessControlServiceDsrUuid();

                var user = _dsrAccessControlProxy.CreateUser(Guid.NewGuid(), dtpUserValidFrom.Value,
                    dtpUserValidUntil.Value);

                var flags = new List<UserFlag>();
                var credentials = new List<Credential>();

                if (chkUserExtended.Checked)
                    flags.Add(UserFlag.EXTENDED);
                if (chkUserSuspended.Checked)
                    flags.Add(UserFlag.SUSPENDED);
                user.userFlags = flags.ToArray();

                var credential = new Credential();
                credential.ordinal = 1;
                if (!string.IsNullOrEmpty(txtCredentialFacilityCode.Text))
                    credential.facilityCode = Convert.ToInt32(txtCredentialFacilityCode.Text);
                credential.format = (CredentialFormat) cbCredentialFormats.SelectedItem;
                credential.value = new CredentialValue();
                if (string.IsNullOrEmpty(txtCredentialIntegerValue.Text) ||
                    credential.format == CredentialFormat.PIN_CODE ||
                    credential.format == CredentialFormat.MAGNETIC_TRACK_2 ||
                    credential.format == CredentialFormat.PROX_RAW)
                {
                    credential.value.stringValue = txtCredentialStringValue.Text;
                }
                else
                {
                    credential.value.intValue = Convert.ToInt32(txtCredentialIntegerValue.Text);
                    credential.value.intValueSpecified = true;
                }

                credentials.Add(credential);

                if (!string.IsNullOrEmpty(this.txtCredentialPINStringValue.Text))
                {
                    var pinCredential = new Credential();
                    pinCredential.format = CredentialFormat.PIN_CODE;
                    pinCredential.ordinal = 2;
                    pinCredential.value = new CredentialValue();
                    pinCredential.value.stringValue = txtCredentialPINStringValue.Text;
                    credentials.Add(pinCredential);
                }
                user.credentials = credentials.ToArray();

                var data =
                    await
                        _dsrAccessControlProxy.AddUserAsync(user, uuid);
                if (data != null)
                {
                    var sb = new StringBuilder();
                    sb.Append(methodName);
                    sb.Append(string.Format("\n\tUserId:{0}", data));
                    LogInformation(sb.ToString());
                }
            }
            catch (Exception ex)
            {
                Log(methodName, ex);
            }
        }

        private Guid GetUserId()
        {
            string id = cbUserIds.SelectedItem.ToString();
            var idGuid = new Guid(id);
            return idGuid;
        }

        private async void btnGetUserIds_Click(object sender, EventArgs e)
        {
            var methodName = DsrAccessControlServiceMethodNames.GetUserIds;
            lblUserCount.Text = string.Empty;
            try
            {
                cbUserIds.Items.Clear();
                var data =
                    await
                        _dsrAccessControlProxy.GetUserIdsAsync();
                lblUserCount.Text = data.Count().ToString();

                FillComboBox(data, ref cbUserIds);
                FillCheckedListBox(data, ref clbAuthorizationAuthorizeUsers);

                if (data != null)
                {
                    var sb = new StringBuilder();
                    sb.Append(methodName);
                    LogInformation(sb.ToString());
                }
            }
            catch (Exception ex)
            {
                Log(methodName, ex);
            }
        }

        private async void btnRemoveUser_Click(object sender, EventArgs e)
        {
            var methodName = DsrAccessControlServiceMethodNames.RemoveUser;
            var userId = GetUserId();
            if (userId != Guid.Empty)
            {
                try
                {
                    var data =
                        await
                            _dsrAccessControlProxy.RemoveUserAsync(userId, null);
                    if (data != null)
                    {
                        var sb = new StringBuilder();
                        sb.Append(methodName);
                        LogInformation(sb.ToString());
                    }
                }
                catch (Exception ex)
                {
                    Log(methodName, ex);
                }
            }
        }

        private async void btnModifyUser_Click(object sender, EventArgs e)
        {
            var methodName = DsrAccessControlServiceMethodNames.ModifyUser;
            try
            {
                var uuid = _dsrAccessControlProxy.CreateAccessControlServiceDsrUuid();
                Guid userId = GetUserId();
                var user = _dsrAccessControlProxy.CreateUser(userId, dtpUserValidFrom.Value, dtpUserValidUntil.Value);
                var flags = new List<UserFlag>();
                var credentials = new List<Credential>();

                if (chkUserExtended.Checked)
                    flags.Add(UserFlag.EXTENDED);
                if (chkUserSuspended.Checked)
                    flags.Add(UserFlag.SUSPENDED);
                user.userFlags = flags.ToArray();

                var credential = new Credential();
                credential.ordinal = 1;
                credential.format = (CredentialFormat) cbCredentialFormats.SelectedItem;
                if (!string.IsNullOrEmpty(txtCredentialFacilityCode.Text))
                    credential.facilityCode = Convert.ToInt32(txtCredentialFacilityCode.Text);
                credential.value = new CredentialValue();
                if (string.IsNullOrEmpty(txtCredentialIntegerValue.Text) ||
                    credential.format == CredentialFormat.PIN_CODE ||
                    credential.format == CredentialFormat.MAGNETIC_TRACK_2 ||
                    credential.format == CredentialFormat.PROX_RAW)
                {
                    credential.value.stringValue = txtCredentialStringValue.Text;
                }
                else
                {
                    credential.value.intValue = Convert.ToInt32(txtCredentialIntegerValue.Text);
                    credential.value.intValueSpecified = true;
                }

                credentials.Add(credential);

                if (!string.IsNullOrEmpty(this.txtCredentialPINStringValue.Text))
                {
                    var pinCredential = new Credential();
                    pinCredential.format = CredentialFormat.PIN_CODE;
                    pinCredential.ordinal = 2;
                    pinCredential.value = new CredentialValue();
                    pinCredential.value.stringValue = txtCredentialPINStringValue.Text;
                    credentials.Add(pinCredential);
                }


                user.credentials = credentials.ToArray();

                var data =
                    await
                        _dsrAccessControlProxy.ModifyUserAsync(user, uuid);
                if (data != null)
                {
                    var sb = new StringBuilder();
                    sb.Append(methodName);
                    LogInformation(sb.ToString());
                }
            }
            catch (Exception ex)
            {
                Log(methodName, ex);
            }
        }

        private async void btnRemoveUserCascading_Click(object sender, EventArgs e)
        {
            var methodName = DsrAccessControlServiceMethodNames.RemoveUserCascading;
            var userId = GetUserId();
            if (userId != Guid.Empty)
            {
                try
                {
                    var data =
                        await
                            _dsrAccessControlProxy.RemoveUserCascadingAsync(userId, null);
                    if (data != null)
                    {
                        var sb = new StringBuilder();
                        sb.Append(methodName);
                        LogInformation(sb.ToString());
                    }
                }
                catch (Exception ex)
                {
                    Log(methodName, ex);
                }
            }
        }

        private void txtCredentialFacilityCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            NumbersOnly(sender, e);
        }

        private void txtCredentialIntegerValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            NumbersOnly(sender, e);
        }

        private static void NumbersOnly(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        #region Callback methods

        public static void addEventText(string text)
        {
            var result = text;

            if (callbackText.InvokeRequired)
            {
                // It's on a different thread, so use Invoke.
                SetTextCallback d = SetCallbackText;
                callbackText.Invoke
                    (d, result);
            }
            else
            {
                // It's on the same thread, no need for Invoke
                SetCallbackText(result);
            }
        }

        private delegate void SetTextCallback(string text);

        // This method is passed in to the SetTextCallBack delegate
        // to set the Text property of textBox1.
        private static void SetCallbackText(string text)
        {
            callbackText.Text = text + Environment.NewLine + callbackText.Text;
        }

        #endregion

        #region Private Helpers

        private void Log(string message, Exception ex)
        {
            Trace.WriteLine($"{DateTimeOffset.Now} - {message}");
            Trace.Write(ex.ToString());
            txtErrors.Text = string.Format("{0} - {1}\n{2}", DateTimeOffset.Now, message, ex);
        }

        private void LogInformation(string message)
        {
            txtInformation.Text = string.Format("{0} - {1}", DateTimeOffset.Now, message);
        }

        private void FillComboBox(IEnumerable data, ref ComboBox comboBox)
        {
            if (comboBox.DataSource != null)
                comboBox.DataSource = null;
            comboBox.Items.Clear();
            if (data != null)
            {
                foreach (var i in data)
                {
                    comboBox.Items.Add(i);
                }
            }
        }

        private void FillListBox(IEnumerable data, ref ListBox listBox)
        {
            if (listBox.DataSource != null)
                listBox.DataSource = null;
            listBox.Items.Clear();
            if (data != null)
            {
                foreach (var i in data)
                {
                    listBox.Items.Add(i);
                }
            }
        }

        private void FillCheckedListBox(IEnumerable data, ref CheckedListBox list)
        {
            if (list.DataSource != null)
                list.DataSource = null;
            list.Items.Clear();
            if (data != null)
            {
                foreach (var i in data)
                {
                    list.Items.Add(i);
                }
            }
        }

        private string[] GetCheckedItemsAsStringArray(ref CheckedListBox list)
        {
            var array = new List<string>();
            foreach (var item in list.CheckedItems)
                array.Add(item.ToString());
            return array.ToArray();
        }

        private string[] GetCheckedAccessPointsIdsAsStringArray(ref CheckedListBox list)
        {
            var array = new List<string>();
            foreach (var item in list.CheckedItems)
            {
                var ap = item as GCS.AssaAbloyDSR.DSRManagementService.AccessPoint;
                if (ap != null)
                    array.Add(ap.id);
            }
            return array.ToArray();
        }

        private void SetCheckedForAllItems(ref CheckedListBox list, bool isChecked)
        {
            foreach (int i in list.CheckedIndices)
            {
                list.SetItemChecked(i, isChecked);
            }
        }

        private void SetSelectedManagementAccessPoint(GCS.AssaAbloyDSR.DSRManagementService.AccessPoint accessPoint)
        {
            SelectedManagementTabAccessPoint = accessPoint;
            var bEnabled = SelectedManagementTabAccessPoint != null;
            btnGetAccessPointStatus.Enabled = bEnabled;
            btnSetAccessPointEndpointParams.Enabled = false; //Purposely keep this on disabled bEnabled;
            btnRemoveAccessPoint.Enabled = bEnabled;
            btnClearAccessPoint.Enabled = bEnabled;
            btnReplaceAccessPoint.Enabled = bEnabled;
            btnDisableAccessPoint.Enabled = bEnabled;
            btnEnableAccessPoint.Enabled = bEnabled;
            btnVerifyAccessPointOnline.Enabled = bEnabled;
            btnConfirmAccessPoint.Enabled = bEnabled;
            txtAccessPointDescription.Enabled = bEnabled;
            btnAddReaderDescription.Enabled = bEnabled;
        }

        private void SetSelectedAccessControlAccessPoint(GCS.AssaAbloyDSR.DSRManagementService.AccessPoint accessPoint)
        {
            SelectedAccessControlTabAccessPoint = accessPoint;
            var bEnabled = SelectedAccessControlTabAccessPoint != null;
            grpAccessControlAccessPointOperations.Enabled = bEnabled;
        }

        #endregion

        #region Management Service Operations

        private async void btnListAllAccessPoints_Click(object sender, EventArgs e)
        {
            var methodName = DsrManagementServiceMethodNames.ListAllAccessPoints;
            lblAccessPointCount.Text = string.Empty;
            try
            {
                var data = await _dsrManagementProxy.GetAllAccessPointsAsync();
                FillComboBox(data, ref cbAllAccessPoints);
                lblAccessPointCount.Text = data.Count().ToString();

                FillComboBox(data, ref cbAccessControlServiceAccessPoints);
                FillCheckedListBox(data, ref clbAccessPointModeAccessPointList);
                FillCheckedListBox(data, ref clbUserAuthorizeAccessPoints);
                FillCheckedListBox(data, ref clbAuthorizationAuthorizeAccessPoints);

                var sb = new StringBuilder();
                sb.Append(methodName);

                foreach (var accessPoint in data)
                {
                    sb.Append(
                        string.Format(
                            "\n\tSN:{0}, ID:{1}, PointType:{2}, LastSeen:{3}, Confirmed:{4}, Online:{5}, SyncStatus:{6}",
                            accessPoint.serialNumber,
                            accessPoint.id,
                            accessPoint.accessPointType.displayName,
                            accessPoint.lastSeen,
                            accessPoint.confirmed,
                            accessPoint.online,
                            accessPoint.syncStatus));
                    foreach (var attr in accessPoint.accessPointAttributes)
                    {
                        sb.Append(string.Format("\n\tAttribute:{0}, Value:{1}", attr.name, attr.Value));
                    }
                }
                LogInformation(sb.ToString());
            }
            catch (Exception ex)
            {
                Log(methodName, ex);
            }
        }

        private async void btnListAccessPoints_Click(object sender, EventArgs e)
        {
            var methodName = DsrManagementServiceMethodNames.ListAccessPoints;
            try
            {
                if (SelectedAccessPointType != null)
                {
                    var data = await _dsrManagementProxy.GetAccessPointsAsync(SelectedAccessPointType.id);

                    FillComboBox(data, ref cbAccessPointsByType);

                    var sb = new StringBuilder();
                    sb.Append(methodName);
                    foreach (var accessPoint in data)
                    {
                        sb.Append(
                            string.Format(
                                "\n\tSN:{0}, ID:{1}, PointType:{2}, LastSeen:{3}, Confirmed:{4}, Online:{5}, SyncStatus:{6}",
                                accessPoint.serialNumber,
                                accessPoint.id,
                                accessPoint.accessPointType.displayName,
                                accessPoint.lastSeen,
                                accessPoint.confirmed,
                                accessPoint.online,
                                accessPoint.syncStatus));
                    }
                    LogInformation(sb.ToString());
                }
            }
            catch (Exception ex)
            {
                Log(methodName, ex);
            }
        }

        private async void btnGetAccessPointTypes_Click(object sender, EventArgs e)
        {
            var methodName = DsrManagementServiceMethodNames.GetAccessPointTypes;
            try
            {
                var data = await _dsrManagementProxy.GetAccessPointTypesAsync();

                FillComboBox(data, ref cbAccessPointTypes);
                var sb = new StringBuilder();
                sb.Append(methodName);

                foreach (var accessPointType in data)
                {
                    sb.Append(string.Format("\n\tID:{0}, DisplayName:{1}",
                        accessPointType.id, accessPointType.displayName));
                }
                LogInformation(sb.ToString());
            }
            catch (Exception ex)
            {
                Log(methodName, ex);
            }
        }

        private async void btnListAccessPointsOnline_Click(object sender, EventArgs e)
        {
            var methodName = DsrManagementServiceMethodNames.ListAccessPointsOnline;
            try
            {
                var data = await _dsrManagementProxy.GetAccessPointsOnlineAsync(SelectedAccessPointType.id);

                FillComboBox(data, ref cbAccessPointsOnline);
                var sb = new StringBuilder();
                sb.Append(methodName);

                foreach (var accessPoint in data)
                {
                    sb.Append(
                        string.Format(
                            "\n\tSN:{0}, ID:{1}, PointType:{2}, LastSeen:{3}, Confirmed:{4}, Online:{5}, SyncStatus:{6}",
                            accessPoint.serialNumber,
                            accessPoint.id,
                            accessPoint.accessPointType.displayName,
                            accessPoint.lastSeen,
                            accessPoint.confirmed,
                            accessPoint.online,
                            accessPoint.syncStatus));
                }
                LogInformation(sb.ToString());
            }
            catch (Exception ex)
            {
                Log(methodName, ex);
            }
        }

        private async void btnGetAccessPointStatus_Click(object sender, EventArgs e)
        {
            var methodName = DsrManagementServiceMethodNames.GetAccessPointStatus;
            try
            {
                var data = await _dsrManagementProxy.GetAccessPointStatusAsync(SelectedManagementTabAccessPoint.id);
                var sb = new StringBuilder();
                sb.Append(methodName);

                sb.Append(
                    string.Format(
                        "\n\tSN:{0}, ID:{1}, PointType:{2}, LastSeen:{3}, Confirmed:{4}, Online:{5}, SyncStatus:{6}",
                        data.accessPoint.serialNumber,
                        data.accessPoint.id,
                        data.accessPoint.accessPointType.displayName,
                        data.accessPoint.lastSeen,
                        data.accessPoint.confirmed,
                        data.accessPoint.online,
                        data.accessPoint.syncStatus));
                LogInformation(sb.ToString());
            }
            catch (Exception ex)
            {
                Log(methodName, ex);
            }
        }

        private async void btnFindAccessPointBySerialNumber_Click(object sender, EventArgs e)
        {
            var methodName = DsrManagementServiceMethodNames.FindAccessPointBySerialNumber;
            try
            {
                var data =
                    await
                        _dsrManagementProxy.FindAccessPointBySerialNumberAsync(
                            SelectedManagementTabAccessPoint.serialNumber);
                var sb = new StringBuilder();
                sb.Append(methodName);

                sb.Append(
                    string.Format(
                        "\n\tSN:{0}, ID:{1}, PointType:{2}, LastSeen:{3}, Confirmed:{4}, Online:{5}, SyncStatus:{6}",
                        data.serialNumber,
                        data.id,
                        data.accessPointType.displayName,
                        data.lastSeen,
                        data.confirmed,
                        data.online,
                        data.syncStatus));
                LogInformation(sb.ToString());
            }
            catch (Exception ex)
            {
                Log(methodName, ex);
            }
        }

        private async void btnVerifyAccessPointOnline_Click(object sender, EventArgs e)
        {
            var methodName = DsrManagementServiceMethodNames.VerifyAccessPointOnline;
            try
            {
                var data = await _dsrManagementProxy.VerifyAccessPointOnlineAsync(SelectedManagementTabAccessPoint.id);
                var sb = new StringBuilder();
                sb.Append(methodName);

                sb.Append(string.Format("\n\tValue:{0}",
                    data));
                LogInformation(sb.ToString());
            }
            catch (Exception ex)
            {
                Log(methodName, ex);
            }
        }

        private async void btnConfirmAccessPoint_Click(object sender, EventArgs e)
        {
            var methodName = DsrManagementServiceMethodNames.ConfirmAccessPoint;
            try
            {
                var data = await _dsrManagementProxy.ConfirmAccessPointAsync(SelectedManagementTabAccessPoint.id, true);

                var sb = new StringBuilder();
                sb.Append(methodName);

                LogInformation(sb.ToString());
            }
            catch (Exception ex)
            {
                Log(methodName, ex);
            }
        }

        private async void btnAddAndConfirmAccessPoint_Click(object sender, EventArgs e)
        {
            var methodName = DsrManagementServiceMethodNames.AddAndConfirmAccessPoint;
            try
            {
                if (string.IsNullOrEmpty(txtAddAccessPointSerialNumber.Text))
                    return;
                var data = await _dsrManagementProxy.AddAndConfirmAccessPointAsync(SelectedAccessPointType.id,
                    txtAddAccessPointSerialNumber.Text);
                var sb = new StringBuilder();
                sb.Append(methodName);
                if (data != null)
                    sb.Append(string.Format("\n\tID:{0}", data));
                LogInformation(sb.ToString());
            }
            catch (Exception ex)
            {
                Log(methodName, ex);
            }
        }

        private async void btnAddReaderDescription_Click(object sender, EventArgs e)
        {
            var methodName = DsrManagementServiceMethodNames.AddReaderDescription;
            try
            {
                if (SelectedManagementTabAccessPoint == null)
                    return;
                var data = await _dsrManagementProxy.AddReaderDescriptionAsync(SelectedManagementTabAccessPoint.id,
                    txtAccessPointDescription.Text);
                var sb = new StringBuilder();
                sb.Append(methodName);
                LogInformation(sb.ToString());
            }
            catch (Exception ex)
            {
                Log(methodName, ex);
            }
        }

        private async void btnRegisterCallback_Click(object sender, EventArgs e)
        {
            var methodName = DsrManagementServiceMethodNames.RegisterCallback;
            try
            {
                callbackUrl = string.Format("http://{0}:{1}/callback",
                    this.txtCallbackAddress.Text,
                    this.txtCallbackPort.Text);
                //var data = await _dsrManagementProxy.RegisterCallbackAsync(callbackUrl);
                var data = await _dsrManagementProxy.RegisterCallbackAsync(callbackUrl);
                var sb = new StringBuilder();
                sb.Append(methodName);
                LogInformation(sb.ToString());
            }
            catch (Exception ex)
            {
                Log(methodName, ex);
            }
        }

        private async void btnListCallbackEndpoints_Click(object sender, EventArgs e)
        {
            var methodName = DsrManagementServiceMethodNames.ListCallbackEndpoints;
            try
            {
                var data = await _dsrManagementProxy.ListCallbackEndpointsAsync();
                var sb = new StringBuilder();
                sb.Append(methodName);
                foreach (var ep in data)
                {
                    sb.Append(string.Format("\n\tURL:{0}, FailedCallbacks:{1}, LastFailedCallback:{2}",
                        ep.url,
                        ep.failedCallbacks,
                        ep.lastFailedCallbackDate));
                }

                LogInformation(sb.ToString());
            }
            catch (Exception ex)
            {
                Log(methodName, ex);
            }
        }

        private async void UnregisterCallbackUrl(string url)
        {
            if (_dsrManagementProxy == null)
                return;

             var methodName = DsrManagementServiceMethodNames.UnRegisterCallback;
            try
            {
                var data = await _dsrManagementProxy.UnRegisterCallbackAsync(url);
                var sb = new StringBuilder();
                sb.Append(methodName);
                LogInformation(sb.ToString());
            }
            catch (Exception ex)
            {
                Log(methodName, ex);
            }           
        }

        private async void btnUnregisterCallback_Click(object sender, EventArgs e)
        {
            callbackUrl = string.Format("http://{0}:{1}/callback",
                    this.txtCallbackAddress.Text,
                    this.txtCallbackPort.Text);

            UnregisterCallbackUrl(callbackUrl);
        }

        private async void btnGetSupportedCredentialFormats_Click(object sender, EventArgs e)
        {
            var methodName = DsrManagementServiceMethodNames.GetSupportedCredentialFormats;
            try
            {
                if (SelectedAccessPointType != null)
                {
                    var data = await _dsrManagementProxy.GetSupportedCredentialFormatsAsync(SelectedAccessPointType.id);
                    var sb = new StringBuilder();
                    sb.Append(methodName);
                    if (data != null)
                    {
                        foreach (var credentialFormat in data)
                        {
                            sb.Append(string.Format("\n\t{0}", credentialFormat));
                        }
                    }
                    LogInformation(sb.ToString());
                }
            }
            catch (Exception ex)
            {
                Log(methodName, ex);
            }
        }

        private async void btnGetVersionInfo_Click(object sender, EventArgs e)
        {
            var methodName = DsrManagementServiceMethodNames.GetVersionInfo;
            try
            {
                var data = await _dsrManagementProxy.GetVersionInfoAsync();
                var sb = new StringBuilder();
                sb.Append(methodName);
                if (data != null)
                {
                    sb.Append(string.Format("\n\tServerVersion:{0}, ServerBuildNumber:{1}",
                        data.serverVersion,
                        data.serverBuildNumber));
                    foreach (var moduleVersion in data.moduleVersion)
                    {
                        sb.Append(string.Format("\n\t\tModuleName:{0}, ModuleVersion:{1}, ModuleBuildNumber:{2}",
                            moduleVersion.moduleName,
                            moduleVersion.moduleVersion1,
                            moduleVersion.moduleBuildNumber));
                    }
                }
                LogInformation(sb.ToString());
            }
            catch (Exception ex)
            {
                Log(methodName, ex);
            }
        }

        private async void btnGetStatus_Click(object sender, EventArgs e)
        {
            var methodName = DsrManagementServiceMethodNames.GetStatus;
            try
            {
                var data = await _dsrManagementProxy.GetStatusAsync();
                var sb = new StringBuilder();
                sb.Append(methodName);
                if (data != null)
                {
                    sb.Append(string.Format("\n\tLastTimeDSRGotOnline:{0}, LastTimeDsrGotOnlineSpecified:{1}",
                        data.lastTimeDsrGotOnline, data.lastTimeDsrGotOnlineSpecified));
                }
                LogInformation(sb.ToString());
            }
            catch (Exception ex)
            {
                Log(methodName, ex);
            }
        }

        private async void btnSetAccessPointEndpointParams_Click(object sender, EventArgs e)
        {
            var methodName = DsrManagementServiceMethodNames.SetAccessPointEndpointParams;
            try
            {
                //if (SelectedManagementTabAccessPoint == null)
                //    return;
                //var epParams = new EndpointParam();

                //var data = await _dsrManagementProxy.SetAccessPointEndpointParamsAsync(SelectedAccessControlTabAccessPoint.id, epParams);
                //var sb = new StringBuilder();
                //sb.Append("setAccessPointEndpointParams");
                //LogInformation(sb.ToString());
            }
            catch (Exception ex)
            {
                Log(methodName, ex);
            }
        }

        private async void btnRemoveAccessPoint_Click(object sender, EventArgs e)
        {
            var methodName = DsrManagementServiceMethodNames.RemoveAccessPoint;
            try
            {
                if (SelectedManagementTabAccessPoint == null)
                    return;
                if (MessageBox.Show("Are You Sure?", "Confirm", MessageBoxButtons.YesNo) != DialogResult.Yes)
                    return;
                var data = await _dsrManagementProxy.RemoveAccessPointAsync(SelectedManagementTabAccessPoint.id);
                var sb = new StringBuilder();
                sb.Append(methodName);
                //if (data != null)
                //{
                //    sb.Append(string.Format("\n\tLastTimeDSRGotOnline:{0}, LastTimeDsrGotOnlineSpecified:{1}",
                //        data.onlineSince.lastTimeDsrGotOnline, data.onlineSince.lastTimeDsrGotOnlineSpecified));
                //}
                LogInformation(sb.ToString());
            }
            catch (Exception ex)
            {
                Log(methodName, ex);
            }
        }

        private async void btnClearAccessPoint_Click(object sender, EventArgs e)
        {
            var methodName = DsrManagementServiceMethodNames.ClearAccessPoint;
            try
            {
                if (SelectedManagementTabAccessPoint == null)
                    return;
                if (MessageBox.Show("Are You Sure?", "Confirm", MessageBoxButtons.YesNo) != DialogResult.Yes)
                    return;
                var data = await _dsrManagementProxy.ClearAccessPointAsync(SelectedManagementTabAccessPoint.id);
                var sb = new StringBuilder();
                sb.Append(methodName);
                //if (data != null)
                //{
                //    sb.Append(string.Format("\n\tLastTimeDSRGotOnline:{0}, LastTimeDsrGotOnlineSpecified:{1}",
                //        data.onlineSince.lastTimeDsrGotOnline, data.onlineSince.lastTimeDsrGotOnlineSpecified));
                //}
                LogInformation(sb.ToString());
            }
            catch (Exception ex)
            {
                Log(methodName, ex);
            }
        }

        private async void btnReplaceAccessPoint_Click(object sender, EventArgs e)
        {
            var methodName = DsrManagementServiceMethodNames.ReplaceAccessPoint;
            try
            {
                if (SelectedManagementTabAccessPoint == null)
                    return;

                if (MessageBox.Show("Are You Sure?", "Confirm", MessageBoxButtons.YesNo) != DialogResult.Yes)
                    return;
                var newSerialNumber = "9876543210";
                var data =
                    await
                        _dsrManagementProxy.ReplaceAccessPointAsync(SelectedManagementTabAccessPoint.id, newSerialNumber);

                var sb = new StringBuilder();
                sb.Append(methodName);
                //if (data != null)
                //{
                //    sb.Append(string.Format("\n\tLastTimeDSRGotOnline:{0}, LastTimeDsrGotOnlineSpecified:{1}",
                //        data.onlineSince.lastTimeDsrGotOnline, data.onlineSince.lastTimeDsrGotOnlineSpecified));
                //}
                LogInformation(sb.ToString());
            }
            catch (Exception ex)
            {
                Log(methodName, ex);
            }
        }

        private async void btnDisableAccessPoint_Click(object sender, EventArgs e)
        {
            var methodName = DsrManagementServiceMethodNames.DisableAccessPoint;
            try
            {
                if (SelectedManagementTabAccessPoint == null)
                    return;
                var data = await _dsrManagementProxy.DisableAccessPointAsync(SelectedManagementTabAccessPoint.id);
                var sb = new StringBuilder();
                sb.Append(methodName);
                LogInformation(sb.ToString());
            }
            catch (Exception ex)
            {
                Log(methodName, ex);
            }
        }

        private async void btnEnableAccessPoint_Click(object sender, EventArgs e)
        {
            var methodName = DsrManagementServiceMethodNames.EnableAccessPoint;
            try
            {
                if (SelectedManagementTabAccessPoint == null)
                    return;
                var data = await _dsrManagementProxy.EnableAccessPointAsync(SelectedManagementTabAccessPoint.id);
                var sb = new StringBuilder();
                sb.Append(methodName);
                LogInformation(sb.ToString());
            }
            catch (Exception ex)
            {
                Log(methodName, ex);
            }
        }

        #endregion

        #region Private methods

        private void cbAllAccessPoints_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetSelectedManagementAccessPoint(
                cbAllAccessPoints.SelectedItem as GCS.AssaAbloyDSR.DSRManagementService.AccessPoint);
        }

        private void cbAccessPointsByType_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetSelectedManagementAccessPoint(
                cbAccessPointsByType.SelectedItem as GCS.AssaAbloyDSR.DSRManagementService.AccessPoint);
        }

        private void cbAccessPointTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedAccessPointType =
                cbAccessPointTypes.SelectedItem as GCS.AssaAbloyDSR.DSRManagementService.AccessPointType;
            var bEnabled = SelectedAccessPointType != null;
            btnListAccessPoints.Enabled = bEnabled;
            btnListAccessPointsOnline.Enabled = bEnabled;
            btnGetSupportedCredentialFormats.Enabled = bEnabled;
            txtAddAccessPointSerialNumber.Enabled = bEnabled;
            btnAddAndConfirmAccessPoint.Enabled = bEnabled && !string.IsNullOrEmpty(txtAddAccessPointSerialNumber.Text);
        }

        #endregion

        private async void btnAuthorizeAllUsersAllLocks_Click(object sender, EventArgs e)
        {
            var methodName = DsrAccessControlServiceMethodNames.AddAuthorization;
            try
            {
                var uuid = _dsrAccessControlProxy.CreateAccessControlServiceDsrUuid();
                var authorization = new Authorization();
                var authorizationTypes = new List<AuthorizationType>();

                var accessPoints = await _dsrManagementProxy.GetAllAccessPointsAsync();
                var users = await _dsrAccessControlProxy.GetUserIdsAsync();

                authorizationTypes.Add(AuthorizationType.ACCESS);
                authorization.authorizationType = authorizationTypes.ToArray();
                authorization.accessPointId = accessPoints.Select(p => p.id).ToArray();
                authorization.userId = users.ToArray();
                authorization.scheduleId = GCS.AssaAbloyDSR.DsrAccessControlProxy.AlwaysOnScheduleId;

                var data = await _dsrAccessControlProxy.AddAuthorizationAsync(authorization, uuid);
                var sb = new StringBuilder();
                sb.Append(methodName);
                LogInformation(sb.ToString());
            }
            catch (Exception ex)
            {
                Log(methodName, ex);
            }
        }

        private async void cbUserIds_SelectedIndexChanged(object sender, EventArgs e)
        {
            var methodName = DsrAccessControlServiceMethodNames.FindUsers;
            try
            {
                Guid userId;
                if (Guid.TryParse(cbUserIds.SelectedItem as string, out userId))
                {
                    var userIds = new List<Guid>();
                    userIds.Add(userId);
                    var users = await _dsrAccessControlProxy.FindUsersAsync(userIds);
                    if (users != null)
                    {
                        foreach (var user in users)
                        {
                            DisplayUser(user);
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Log(methodName, ex);
            }
        }

        private void DisplayUser(User u)
        {
            dtpUserValidFrom.Value = dtpUserValidFrom.MinDate;
            dtpUserValidUntil.Value = dtpUserValidUntil.MaxDate;
            chkUserExtended.Checked = false;
            chkUserSuspended.Checked = false;
            txtCredentialStringValue.Text = string.Empty;
            txtCredentialFacilityCode.Text = string.Empty;
            txtCredentialIntegerValue.Text = string.Empty;
            txtCredentialPINStringValue.Text = string.Empty;

            cbCredentialFormats.SelectedItem = null;
            if (u == null)
                return;

            if (u.userFlags != null)
            {
                foreach (var userFlag in u.userFlags)
                {
                    switch (userFlag)
                    {
                        case UserFlag.EXTENDED:
                            chkUserExtended.Checked = true;
                            break;

                        case UserFlag.SUSPENDED:
                            chkUserSuspended.Checked = true;
                            break;
                    }
                }
            }


            if (u.validity != null)
            {
                if (u.validity.start != null)
                {
                    var dt = u.validity.start.ToDateTime();
                    if (dt <= dtpUserValidFrom.MinDate)
                        dt = dtpUserValidUntil.MinDate;
                    dtpUserValidFrom.Value = dt;
                }

                if (u.validity.end != null)
                {
                    var dt1 = u.validity.end.ToDateTime();
                    if (dt1 >= dtpUserValidUntil.MaxDate)
                        dt1 = dtpUserValidUntil.MaxDate;
                    dtpUserValidUntil.Value = dt1;
                }
            }

            if (u.credentials.Length > 0)
            {
                var credential = u.credentials[0];
                cbCredentialFormats.SelectedItem = credential.format;
                txtCredentialFacilityCode.Text = credential.facilityCode.ToString();
                txtCredentialIntegerValue.Text = credential.value.intValue.ToString();
                txtCredentialStringValue.Text = credential.value.stringValue;
            }

            if (u.credentials.Length > 1)
            {
                var credential = u.credentials[1];
                txtCredentialPINStringValue.Text = credential.value.stringValue;
            }
        }

        private async void btnSetAllLocksAccessPrimaryOnlyMode_Click(object sender, EventArgs e)
        {
            var methodName = DsrAccessControlServiceMethodNames.AddAccessPointMode;
            try
            {
                var uuid = _dsrAccessControlProxy.CreateAccessControlServiceDsrUuid();

                var accessPoints = await _dsrManagementProxy.GetAllAccessPointsAsync();

                var accessPointMode = new AccessPointMode();
                accessPointMode.accessPointModeType = AccessPointModeType.ACCESSMODE_PRIMARY;
                accessPointMode.scheduleId = GCS.AssaAbloyDSR.DsrAccessControlProxy.AlwaysOnScheduleId;
                accessPointMode.accessPointIds = accessPoints.Select(p => p.id).ToArray();

                var data = await _dsrAccessControlProxy.AddAccessPointModeAsync(accessPointMode, uuid);
                var sb = new StringBuilder();
                sb.Append(methodName);
                LogInformation(sb.ToString());
            }
            catch (Exception ex)
            {
                Log(methodName, ex);
            }
        }

        private async void btnGetDayPeriodIds_Click(object sender, EventArgs e)
        {
            var methodName = DsrAccessControlServiceMethodNames.GetDayPeriodIds;
            try
            {
                var uuid = _dsrAccessControlProxy.CreateAccessControlServiceDsrUuid();

                var ids = await _dsrAccessControlProxy.GetDayPeriodIdsAsync();
                FillComboBox(ids, ref cbDayPeriodIdList);
                FillCheckedListBox(ids, ref clbScheduleDayPeriodCheckedListBox);

                var sb = new StringBuilder();
                sb.Append(methodName);
                foreach (var id in ids)
                {
                    List<Guid> guidList = new List<Guid>();
                    guidList.Add(new Guid(id));
                    var dayPeriod = await _dsrAccessControlProxy.FindDayPeriodsAsync(guidList);

                    sb.Append(
                        string.Format("\n\tDayPeriodId:{0}", id));
                }

                LogInformation(sb.ToString());
            }
            catch (Exception ex)
            {
                Log(methodName, ex);
            }
        }

        private async void cbDayPeriodIdList_SelectedIndexChanged(object sender, EventArgs e)
        {
            var methodName = DsrAccessControlServiceMethodNames.FindDayPeriods;
            try
            {
                var uuid = _dsrAccessControlProxy.CreateAccessControlServiceDsrUuid();
                string id = cbDayPeriodIdList.SelectedItem.ToString();
                var idGuid = new Guid(id);
                if (idGuid != Guid.Empty)
                {
                    DayPeriod dayPeriod = await GetDayPeriodFromDSR(idGuid);

                    for (int x = 0; x < WeekDayCheckBoxList.Items.Count; x++)
                    {
                        WeekDayCheckBoxList.SetItemChecked(x, false);
                        var item = WeekDayCheckBoxList.Items[x];

                        foreach (var weekday in dayPeriod.weekDays)
                        {
                            if (((WeekDay) item) == weekday)
                            {
                                WeekDayCheckBoxList.SetItemChecked(x, true);
                                break;
                            }
                        }
                    }

                    clbDayPeriodTimePeriods.Items.Clear();
                    foreach (var tp in dayPeriod.timePeriods)
                    {
                        var data = new StartEndTimePeriod(tp.start, tp.end);
                        clbDayPeriodTimePeriods.Items.Add(data, true);
                    }
                }
                var sb = new StringBuilder();
                sb.Append(methodName);

                LogInformation(sb.ToString());
            }
            catch (Exception ex)
            {
                Log(methodName, ex);
            }
        }

        private async Task<DayPeriod> GetDayPeriodFromDSR(string idGuid)
        {
            return await GetDayPeriodFromDSR(new Guid(idGuid));
        }

        private async Task<DayPeriod> GetDayPeriodFromDSR(Guid idGuid)
        {
            var ids = new List<Guid>();
            ids.Add(idGuid);
            var dataItems = await _dsrAccessControlProxy.FindDayPeriodsAsync(ids);
            var item = dataItems.First();
            return item;
        }

        private async Task<DayException> GetDayExceptionFromDSR(string idGuid)
        {
            return await GetDayExceptionFromDSR(new Guid(idGuid));
        }

        private async Task<DayException> GetDayExceptionFromDSR(Guid idGuid)
        {
            var ids = new List<Guid>();
            ids.Add(idGuid);
            var dataItems = await _dsrAccessControlProxy.FindDayExceptionsAsync(ids);
            var item = dataItems.First();
            return item;
        }

        private async Task<DayExceptionGroup> GetDayExceptionGroupFromDSR(string idGuid)
        {
            return await GetDayExceptionGroupFromDSR(new Guid(idGuid));
        }

        private async Task<DayExceptionGroup> GetDayExceptionGroupFromDSR(Guid idGuid)
        {
            var ids = new List<Guid>();
            ids.Add(idGuid);
            var dataItems = await _dsrAccessControlProxy.FindDayExceptionGroupsAsync(ids);
            var item = dataItems.First();
            return item;
        }

        private async Task<AccessPointMode> GetAccessPointModeFromDSR(string idGuid)
        {
            return await GetAccessPointModeFromDSR(new Guid(idGuid));
        }

        private async Task<AccessPointMode> GetAccessPointModeFromDSR(Guid idGuid)
        {
            var ids = new List<Guid>();
            ids.Add(idGuid);
            var dataItems = await _dsrAccessControlProxy.FindAccessPointModesAsync(ids);
            var item = dataItems.First();
            return item;
        }


        private async void btnAddDayPeriod_Click(object sender, EventArgs e)
        {
            var methodName = DsrAccessControlServiceMethodNames.AddDayPeriod;
            try
            {
                var uuid = _dsrAccessControlProxy.CreateAccessControlServiceDsrUuid();

                var dayPeriod = GetDayPeriodFromFormData();
                dayPeriod.id = Guid.NewGuid().ToString();

                var dayPeriodId = await _dsrAccessControlProxy.AddDayPeriodAsync(dayPeriod, null);
                cbDayPeriodIdList.Items.Add(dayPeriodId);
                var sb = new StringBuilder();
                sb.Append(methodName);

                LogInformation(sb.ToString());
            }
            catch (Exception ex)
            {
                Log(methodName, ex);
            }
        }


        private void btnDayPeriodAddTimePeriod_Click(object sender, EventArgs e)
        {
            var data = new StartEndTimePeriod(dayPeriodStartTime.Value, dayPeriodEndTime.Value);
            clbDayPeriodTimePeriods.Items.Add(data, true);
        }

        private DayPeriod GetDayPeriodFromFormData()
        {
            var dayPeriod = new DayPeriod();
            var weekDays = new List<WeekDay>();
            foreach (var weekDay in WeekDayCheckBoxList.CheckedItems)
            {
                weekDays.Add((WeekDay) weekDay);
            }

            var timePeriods = new List<TimePeriod>();
            foreach (var item in this.clbDayPeriodTimePeriods.CheckedItems)
            {
                var data = item as StartEndTimePeriod;
                if (data != null)
                {
                    var tp = new TimePeriod();
                    timePeriods.Add(tp.FromStartEndTimePeriod(data));
                }
            }
            dayPeriod.weekDays = weekDays.ToArray();
            dayPeriod.timePeriods = timePeriods.ToArray();
            return dayPeriod;
        }

        private async void btnRemoveDayPeriod_Click(object sender, EventArgs e)
        {
            var methodName = DsrAccessControlServiceMethodNames.RemoveDayPeriod;
            try
            {
                var uuid = _dsrAccessControlProxy.CreateAccessControlServiceDsrUuid();
                string id = cbDayPeriodIdList.SelectedItem.ToString();
                var idGuid = new Guid(id);
                if (idGuid != Guid.Empty)
                {
                    await _dsrAccessControlProxy.RemoveDayPeriodAsync(idGuid, null);
                }
                var sb = new StringBuilder();
                sb.Append(methodName);

                LogInformation(sb.ToString());
                btnGetDayPeriodIds_Click(null, null);
            }
            catch (Exception ex)
            {
                Log(methodName, ex);
            }
        }

        private async void btnModifyDayPeriod_Click(object sender, EventArgs e)
        {
            var methodName = DsrAccessControlServiceMethodNames.ModifyDayPeriod;
            try
            {
                string id = cbDayPeriodIdList.SelectedItem.ToString();
                var idGuid = new Guid(id);
                if (idGuid != Guid.Empty)
                {
                    var uuid = _dsrAccessControlProxy.CreateAccessControlServiceDsrUuid(idGuid);

                    var dayPeriod = GetDayPeriodFromFormData();
                    dayPeriod.id = id;
                    var ret = await _dsrAccessControlProxy.ModifyDayPeriodAsync(dayPeriod, null);
                }
                var sb = new StringBuilder();
                sb.Append(methodName);

                LogInformation(sb.ToString());
            }
            catch (Exception ex)
            {
                Log(methodName, ex);
            }
        }

        private void txtDSRIpAddress_TextChanged(object sender, EventArgs e)
        {
            SaveSettings();
            CreateDsrConnectionParameters();
        }

        private async void btnGetScheduleIds_Click(object sender, EventArgs e)
        {
            var methodName = DsrAccessControlServiceMethodNames.GetScheduleIds;
            try
            {
                var uuid = _dsrAccessControlProxy.CreateAccessControlServiceDsrUuid();

                var ids = await _dsrAccessControlProxy.GetScheduleIdsAsync();
                FillComboBox(ids, ref cbScheduleIdList);
                FillComboBox(ids, ref cbAccessPointModeSchedulesList);
                FillComboBox(ids, ref cbUserAuthorizationSchedule);
                FillComboBox(ids, ref cbAuthorizationAuthorizationSchedule);


                var sb = new StringBuilder();
                sb.Append(methodName);
                foreach (var id in ids)
                {
                    List<Guid> guidList = new List<Guid>();
                    guidList.Add(new Guid(id));
                    var schedule = await _dsrAccessControlProxy.FindSchedulesAsync(guidList);

                    sb.Append(
                        string.Format("\n\tScheduleId:{0}", id));
                }

                LogInformation(sb.ToString());
            }
            catch (Exception ex)
            {
                Log(methodName, ex);
            }
        }

        private async void cbScheduleIdList_SelectedIndexChanged(object sender, EventArgs e)
        {
            var methodName = DsrAccessControlServiceMethodNames.FindSchedules;
            try
            {
                var uuid = _dsrAccessControlProxy.CreateAccessControlServiceDsrUuid();
                string id = cbScheduleIdList.SelectedItem.ToString();
                var idGuid = new Guid(id);
                if (idGuid != Guid.Empty)
                {
                    var scheduleIds = new List<Guid>();
                    scheduleIds.Add(idGuid);
                    var schedules = await _dsrAccessControlProxy.FindSchedulesAsync(scheduleIds);
                    _selectedSchedule = schedules.First();

                    for (int x = 0; x < clbScheduleDayPeriodCheckedListBox.Items.Count; x++)
                    {
                        clbScheduleDayPeriodCheckedListBox.SetItemChecked(x, false);
                        var item = clbScheduleDayPeriodCheckedListBox.Items[x];
                        if (_selectedSchedule.dayPeriodIds != null)
                        {
                            if (_selectedSchedule.dayPeriodIds.Contains(item as string))
                            {
                                clbScheduleDayPeriodCheckedListBox.SetItemChecked(x, true);
                            }
                        }
                    }

                    for (int x = 0; x < clbScheduleDayExceptionGroupIdList.Items.Count; x++)
                    {
                        clbScheduleDayExceptionGroupIdList.SetItemChecked(x, false);
                        var item = clbScheduleDayExceptionGroupIdList.Items[x];
                        if (_selectedSchedule.dayExceptionGroupIds != null)
                        {
                            if (_selectedSchedule.dayExceptionGroupIds.Contains(item as string))
                            {
                                clbScheduleDayExceptionGroupIdList.SetItemChecked(x, true);
                            }
                        }
                    }
                }
                var sb = new StringBuilder();
                sb.Append(methodName);

                LogInformation(sb.ToString());
            }
            catch (Exception ex)
            {
                Log(methodName, ex);
            }
        }

        private async void btnRemoveSchedule_Click(object sender, EventArgs e)
        {
            var methodName = DsrAccessControlServiceMethodNames.RemoveSchedule;
            try
            {
                var uuid = _dsrAccessControlProxy.CreateAccessControlServiceDsrUuid();
                string id = cbScheduleIdList.SelectedItem.ToString();
                var idGuid = new Guid(id);
                if (idGuid != Guid.Empty)
                {
                    await _dsrAccessControlProxy.RemoveScheduleAsync(idGuid, null);
                }
                var sb = new StringBuilder();
                sb.Append(methodName);

                LogInformation(sb.ToString());
                btnGetScheduleIds_Click(null, null);
            }
            catch (Exception ex)
            {
                Log(methodName, ex);
            }
        }

        private async void btnAddSchedule_Click(object sender, EventArgs e)
        {
            var methodName = DsrAccessControlServiceMethodNames.AddSchedule;
            try
            {
                var uuid = _dsrAccessControlProxy.CreateAccessControlServiceDsrUuid();

                Schedule schedule = GetScheduleFromFormData();
                schedule.id = Guid.NewGuid().ToString();

                var scheduleId = await _dsrAccessControlProxy.AddScheduleAsync(schedule, null);
                cbScheduleIdList.Items.Add(scheduleId);
                cbAccessPointModeSchedulesList.Items.Add(scheduleId);

                var sb = new StringBuilder();
                sb.Append(methodName);

                LogInformation(sb.ToString());
            }
            catch (Exception ex)
            {
                Log(methodName, ex);
            }
        }

        private Schedule GetScheduleFromFormData()
        {
            var schedule = new Schedule();

            var dayPeriodIds = new List<string>();
            var dayExceptionGroupIds = new List<string>();

            foreach (var dp in clbScheduleDayPeriodCheckedListBox.CheckedItems)
            {
                dayPeriodIds.Add((string) dp);
            }
            schedule.dayPeriodIds = dayPeriodIds.ToArray();

            foreach (var dp in clbScheduleDayExceptionGroupIdList.CheckedItems)
            {
                dayExceptionGroupIds.Add((string) dp);
            }
            schedule.dayExceptionGroupIds = dayExceptionGroupIds.ToArray();
            return schedule;
        }

        private async void btnModifySchedule_Click(object sender, EventArgs e)
        {
            var methodName = DsrAccessControlServiceMethodNames.ModifySchedule;
            try
            {
                string id = cbScheduleIdList.SelectedItem.ToString();
                var idGuid = new Guid(id);
                if (idGuid != Guid.Empty)
                {
                    var uuid = _dsrAccessControlProxy.CreateAccessControlServiceDsrUuid(idGuid);

                    var schedule = GetScheduleFromFormData();
                    schedule.id = id;
                    var ret = await _dsrAccessControlProxy.ModifyScheduleAsync(schedule, null);
                }
                var sb = new StringBuilder();
                sb.Append(methodName);

                LogInformation(sb.ToString());
            }
            catch (Exception ex)
            {
                Log(methodName, ex);
            }
        }

        private async void btnAddDayPeriodToSchedule_Click(object sender, EventArgs e)
        {
            var methodName = DsrAccessControlServiceMethodNames.AddDayPeriodToSchedule;
            try
            {
                var uuid = _dsrAccessControlProxy.CreateAccessControlServiceDsrUuid();
                var selectedDayPeriodId = clbScheduleDayPeriodCheckedListBox.SelectedItem as string;
                var scheduleId = new Guid(_selectedSchedule.id);
                var data =
                    await
                        _dsrAccessControlProxy.AddDayPeriodToScheduleAsync(scheduleId,
                            new Guid(selectedDayPeriodId), null);
                var sb = new StringBuilder();
                sb.Append(methodName);

                LogInformation(sb.ToString());
            }
            catch (Exception ex)
            {
                Log(methodName, ex);
            }
        }

        private async void btnRemoveDayPeriodFromSchedule_Click(object sender, EventArgs e)
        {
            var methodName = DsrAccessControlServiceMethodNames.RemoveDayPeriodFromSchedule;
            try
            {
                var uuid = _dsrAccessControlProxy.CreateAccessControlServiceDsrUuid();
                var selectedDayPeriodId = clbScheduleDayPeriodCheckedListBox.SelectedItem as string;
                var scheduleId = new Guid(_selectedSchedule.id);
                var data =
                    await
                        _dsrAccessControlProxy.RemoveDayPeriodFromScheduleAsync(scheduleId,
                            new Guid(selectedDayPeriodId), null);
                var sb = new StringBuilder();
                sb.Append(methodName);

                LogInformation(sb.ToString());
            }
            catch (Exception ex)
            {
                Log(methodName, ex);
            }
        }

        private async void btnAddDayExceptionGroupToSchedule_Click(object sender, EventArgs e)
        {
            var methodName = DsrAccessControlServiceMethodNames.AddDayExceptionGroupToSchedule;
            try
            {
                var uuid = _dsrAccessControlProxy.CreateAccessControlServiceDsrUuid();
                var selectedDayExceptionGroupId = clbScheduleDayExceptionGroupIdList.SelectedItem as string;
                var scheduleId = new Guid(_selectedSchedule.id);
                var data =
                    await
                        _dsrAccessControlProxy.AddDayExceptionGroupToScheduleAsync(scheduleId,
                            new Guid(selectedDayExceptionGroupId), null);
                var sb = new StringBuilder();
                sb.Append(methodName);

                LogInformation(sb.ToString());
            }
            catch (Exception ex)
            {
                Log(methodName, ex);
            }
        }

        private async void btnRemoveDayExceptionGroupFromSchedule_Click(object sender, EventArgs e)
        {
            var methodName = DsrAccessControlServiceMethodNames.RemoveDayExceptionGroupFromSchedule;
            try
            {
                var uuid = _dsrAccessControlProxy.CreateAccessControlServiceDsrUuid();
                var selectedDayExceptionGroupId = clbScheduleDayExceptionGroupIdList.SelectedItem as string;
                var scheduleId = new Guid(_selectedSchedule.id);
                var data =
                    await
                        _dsrAccessControlProxy.RemoveDayExceptionGroupFromScheduleAsync(scheduleId,
                            new Guid(selectedDayExceptionGroupId), null);
                var sb = new StringBuilder();
                sb.Append(methodName);

                LogInformation(sb.ToString());
            }
            catch (Exception ex)
            {
                Log(methodName, ex);
            }
        }


        private async void btnGetDayExceptionIds_Click(object sender, EventArgs e)
        {
            var methodName = DsrAccessControlServiceMethodNames.GetDayExceptionIds;
            try
            {
                var uuid = _dsrAccessControlProxy.CreateAccessControlServiceDsrUuid();

                var ids = await _dsrAccessControlProxy.GetDayExceptionIdsAsync();

                FillComboBox(ids, ref cbDayExceptionIdList);
                FillCheckedListBox(ids, ref this.clbDayExceptionGroupsDayExceptionIdList);

                var sb = new StringBuilder();
                sb.Append(methodName);
                foreach (var id in ids)
                {
                    List<Guid> guidList = new List<Guid>();
                    guidList.Add(new Guid(id));
                    var dayExceptions = await _dsrAccessControlProxy.FindDayExceptionsAsync(guidList);

                    sb.Append(
                        string.Format("\n\tDayExceptionId:{0}", id));
                }

                LogInformation(sb.ToString());
            }
            catch (Exception ex)
            {
                Log(methodName, ex);
            }
        }

        private DayException GetDayExceptionFromFormData()
        {
            var dayException = new DayException();
            var localDate = new LocalDate();
            dayException.localDate = localDate.FromDateTime(dtpDayExceptionDate.Value);

            var timePeriods = new List<TimePeriod>();
            foreach (var item in this.clbDayExceptionTimePeriods.CheckedItems)
            {
                var data = item as StartEndTimePeriod;
                if (data != null)
                {
                    var tp = new TimePeriod();
                    timePeriods.Add(tp.FromStartEndTimePeriod(data));
                }
            }
            dayException.timePeriods = timePeriods.ToArray();

            return dayException;
        }

        private async void cbDayExceptionIdList_SelectedIndexChanged(object sender, EventArgs e)
        {
            var methodName = DsrAccessControlServiceMethodNames.FindDayExceptions;
            try
            {
                clbDayExceptionTimePeriods.Items.Clear();
                var uuid = _dsrAccessControlProxy.CreateAccessControlServiceDsrUuid();
                string id = cbDayExceptionIdList.SelectedItem.ToString();
                var idGuid = new Guid(id);
                if (idGuid != Guid.Empty)
                {
                    var ids = new List<Guid>();
                    ids.Add(idGuid);
                    var dayExceptions = await _dsrAccessControlProxy.FindDayExceptionsAsync(ids);
                    var dayException = dayExceptions.First();
                    if (dayException != null)
                    {
                        dtpDayExceptionDate.Value = new DateTime(dayException.localDate.year,
                            dayException.localDate.month, dayException.localDate.dayOfMonth);

                        foreach (var tp in dayException.timePeriods)
                        {
                            var data = new StartEndTimePeriod(tp.start, tp.end);
                            clbDayExceptionTimePeriods.Items.Add(data, true);
                        }
                    }
                }
                var sb = new StringBuilder();
                sb.Append(methodName);

                LogInformation(sb.ToString());
            }
            catch (Exception ex)
            {
                Log(methodName, ex);
            }
        }

        private async void btnRemoveDayException_Click(object sender, EventArgs e)
        {
            var methodName = DsrAccessControlServiceMethodNames.RemoveDayException;
            try
            {
                var uuid = _dsrAccessControlProxy.CreateAccessControlServiceDsrUuid();
                string id = cbDayExceptionIdList.SelectedItem.ToString();
                var idGuid = new Guid(id);
                if (idGuid != Guid.Empty)
                {
                    await _dsrAccessControlProxy.RemoveDayExceptionAsync(idGuid, null);
                }
                var sb = new StringBuilder();
                sb.Append(methodName);

                LogInformation(sb.ToString());
                btnGetDayExceptionIds_Click(null, null);
            }
            catch (Exception ex)
            {
                Log(methodName, ex);
            }
        }

        private async void btnAddDayException_Click(object sender, EventArgs e)
        {
            var methodName = DsrAccessControlServiceMethodNames.AddDayException;
            try
            {
                var uuid = _dsrAccessControlProxy.CreateAccessControlServiceDsrUuid();

                var dayEx = GetDayExceptionFromFormData();

                dayEx.id = Guid.NewGuid().ToString(); // make up a new Id value
                var id = await _dsrAccessControlProxy.AddDayExceptionAsync(dayEx, null);
                cbDayExceptionIdList.Items.Add(id);
                clbDayExceptionGroupsDayExceptionIdList.Items.Add(id);

                cbDayExceptionIdList.SelectedItem = id;
                var sb = new StringBuilder();
                sb.Append(methodName);

                LogInformation(sb.ToString());
            }
            catch (Exception ex)
            {
                Log(methodName, ex);
            }
        }

        private async void btnModifyDayException_Click(object sender, EventArgs e)
        {
            var methodName = DsrAccessControlServiceMethodNames.ModifyDayException;
            try
            {
                string id = cbDayExceptionIdList.SelectedItem.ToString();
                var idGuid = new Guid(id);
                if (idGuid != Guid.Empty)
                {
                    var uuid = _dsrAccessControlProxy.CreateAccessControlServiceDsrUuid();

                    var dayEx = GetDayExceptionFromFormData();
                    dayEx.id = id;
                    var ret = await _dsrAccessControlProxy.ModifyDayExceptionAsync(dayEx, null);
                    cbDayExceptionIdList_SelectedIndexChanged(null, null);
                }
                var sb = new StringBuilder();
                sb.Append(methodName);

                LogInformation(sb.ToString());
            }
            catch (Exception ex)
            {
                Log(methodName, ex);
            }
        }

        private void btnDayExceptionAddTimePeriod_Click(object sender, EventArgs e)
        {
            var data = new StartEndTimePeriod(dtpDayExceptionStartTime.Value, dtpDayExceptionEndTime.Value);
            clbDayExceptionTimePeriods.Items.Add(data, true);
        }

        private async void btnGetDayExceptionGroupIds_Click(object sender, EventArgs e)
        {
            var methodName = DsrAccessControlServiceMethodNames.GetDayExceptionGroupIds;
            try
            {
                var uuid = _dsrAccessControlProxy.CreateAccessControlServiceDsrUuid();

                var ids = await _dsrAccessControlProxy.GetDayExceptionGroupIdsAsync();

                SetCheckedForAllItems(ref this.clbDayExceptionGroupsDayExceptionIdList, false);

                FillComboBox(ids, ref cbDayExceptionGroupIdList);
                FillCheckedListBox(ids, ref this.clbScheduleDayExceptionGroupIdList);

                var sb = new StringBuilder();
                sb.Append(methodName);
                foreach (var id in ids)
                {
                    List<Guid> guidList = new List<Guid>();
                    guidList.Add(new Guid(id));
                    var dayExceptionGroups = await _dsrAccessControlProxy.FindDayExceptionGroupsAsync(guidList);

                    sb.Append(
                        string.Format("\n\tDayExceptionId:{0}", id));
                }

                LogInformation(sb.ToString());
            }
            catch (Exception ex)
            {
                Log(methodName, ex);
            }
        }

        private async void cbDayExceptionGroupIdList_SelectedIndexChanged(object sender, EventArgs e)
        {
            var methodName = DsrAccessControlServiceMethodNames.FindDayExceptionGroups;
            try
            {
                _selectedDayExceptionGroup = null;

                // clear all the checks
                foreach (var x in clbDayExceptionGroupsDayExceptionIdList.CheckedIndices)
                {
                    clbDayExceptionGroupsDayExceptionIdList.SetItemChecked((int) x, false);
                }

                var uuid = _dsrAccessControlProxy.CreateAccessControlServiceDsrUuid();
                string id = cbDayExceptionGroupIdList.SelectedItem.ToString();
                var idGuid = new Guid(id);
                if (idGuid != Guid.Empty)
                {
                    var ids = new List<Guid>();
                    ids.Add(idGuid);
                    var dayExceptionGroups = await _dsrAccessControlProxy.FindDayExceptionGroupsAsync(ids);
                    _selectedDayExceptionGroup = dayExceptionGroups.First();
                    if (_selectedDayExceptionGroup != null)
                    {
                        foreach (var dayExceptionId in _selectedDayExceptionGroup.dayExceptionIds)
                        {
                            for (int x = 0; x < clbDayExceptionGroupsDayExceptionIdList.Items.Count; x++)
                            {
                                var s = clbDayExceptionGroupsDayExceptionIdList.Items[x] as string;
                                if (!string.IsNullOrEmpty(s) && s == dayExceptionId)
                                {
                                    clbDayExceptionGroupsDayExceptionIdList.SetItemChecked(x, true);
                                    break;
                                }
                            }
                        }
                    }
                }
                var sb = new StringBuilder();
                sb.Append(methodName);

                LogInformation(sb.ToString());
            }
            catch (Exception ex)
            {
                Log(methodName, ex);
            }
        }

        private async void btnAddDayExceptionGroup_Click(object sender, EventArgs e)
        {
            var methodName = DsrAccessControlServiceMethodNames.AddDayExceptionGroup;
            try
            {
                var uuid = _dsrAccessControlProxy.CreateAccessControlServiceDsrUuid();

                var dayExGroup = new DayExceptionGroup();

                dayExGroup.id = Guid.NewGuid().ToString(); // make up a new Id value
                dayExGroup.dayExceptionIds = GetCheckedItemsAsStringArray(ref clbDayExceptionGroupsDayExceptionIdList);

                var id = await _dsrAccessControlProxy.AddDayExceptionGroupAsync(dayExGroup, null);
                cbDayExceptionGroupIdList.Items.Add(id);
                clbScheduleDayExceptionGroupIdList.Items.Add(id);

                cbDayExceptionGroupIdList.SelectedItem = id;
                var sb = new StringBuilder();
                sb.Append(methodName);

                LogInformation(sb.ToString());
            }
            catch (Exception ex)
            {
                Log(methodName, ex);
            }
        }

        private async void btnModifyDayExceptionGroup_Click(object sender, EventArgs e)
        {
            var methodName = DsrAccessControlServiceMethodNames.ModifyDayExceptionGroup;
            try
            {
                string id = cbDayExceptionGroupIdList.SelectedItem.ToString();
                var idGuid = new Guid(id);
                if (idGuid != Guid.Empty)
                {
                    var uuid = _dsrAccessControlProxy.CreateAccessControlServiceDsrUuid();

                    var dayExGroup = new DayExceptionGroup();

                    dayExGroup.id = id; // make up a new Id value
                    dayExGroup.dayExceptionIds =
                        GetCheckedItemsAsStringArray(ref clbDayExceptionGroupsDayExceptionIdList);

                    var ret = await _dsrAccessControlProxy.ModifyDayExceptionGroupAsync(dayExGroup, null);
                }
                var sb = new StringBuilder();
                sb.Append(methodName);

                LogInformation(sb.ToString());
            }
            catch (Exception ex)
            {
                Log(methodName, ex);
            }
        }

        private async void btnRemoveDayExceptionGroup_Click(object sender, EventArgs e)
        {
            var methodName = DsrAccessControlServiceMethodNames.RemoveDayExceptionGroup;
            try
            {
                var uuid = _dsrAccessControlProxy.CreateAccessControlServiceDsrUuid();
                string id = cbDayExceptionGroupIdList.SelectedItem.ToString();
                var idGuid = new Guid(id);
                if (idGuid != Guid.Empty)
                {
                    await _dsrAccessControlProxy.RemoveDayExceptionGroupAsync(idGuid, null);
                }
                var sb = new StringBuilder();
                sb.Append(methodName);

                LogInformation(sb.ToString());
                btnGetDayExceptionGroupIds_Click(null, null);
            }
            catch (Exception ex)
            {
                Log(methodName, ex);
            }
        }

        private async void btnAddDayExceptionToDayExceptionGroup_Click(object sender, EventArgs e)
        {
            var methodName = DsrAccessControlServiceMethodNames.AddDayExceptionToDayExceptionGroup;
            try
            {
                var uuid = _dsrAccessControlProxy.CreateAccessControlServiceDsrUuid();
                var selectedDayException = clbDayExceptionGroupsDayExceptionIdList.SelectedItem as string;
                var dayExceptionGroupId = new Guid(_selectedDayExceptionGroup.id);
                var data =
                    await
                        _dsrAccessControlProxy.AddDayExceptionToDayExceptionGroupAsync(dayExceptionGroupId,
                            new Guid(selectedDayException), null);
                var sb = new StringBuilder();
                sb.Append(methodName);

                LogInformation(sb.ToString());
            }
            catch (Exception ex)
            {
                Log(methodName, ex);
            }
        }

        private async void btnRemoveDayExceptionFromDayExceptionGroup_Click(object sender, EventArgs e)
        {
            var methodName = DsrAccessControlServiceMethodNames.RemoveDayExceptionFromDayExceptionGroup;
            try
            {
                var uuid = _dsrAccessControlProxy.CreateAccessControlServiceDsrUuid();
                var selectedDayException = clbDayExceptionGroupsDayExceptionIdList.SelectedItem as string;
                var dayExceptionGroupId = new Guid(_selectedDayExceptionGroup.id);
                var data =
                    await
                        _dsrAccessControlProxy.RemoveDayExceptionFromDayExceptionGroupAsync(dayExceptionGroupId,
                            new Guid(selectedDayException), null);
                var sb = new StringBuilder();
                sb.Append(methodName);

                LogInformation(sb.ToString());
            }
            catch (Exception ex)
            {
                Log(methodName, ex);
            }
        }

        private async void ScheduleDayPeriodCheckedListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnAddDayPeriodToSchedule.Enabled = false;
            btnRemoveDayPeriodFromSchedule.Enabled = false;

            var clb = sender as CheckedListBox;
            if (clb != null && clb.SelectedItem != null)
            {
                var id = clb.SelectedItem as string;
                var dp = await GetDayPeriodFromDSR(id);
                scheduleDayPeriodViewControl.DayPeriod = dp;
                if (dp != null && _selectedSchedule != null)
                {
                    if (_selectedSchedule.dayPeriodIds != null)
                    {
                        if (_selectedSchedule.dayPeriodIds.Contains(dp.id))
                            btnRemoveDayPeriodFromSchedule.Enabled = true;
                        else
                            btnAddDayPeriodToSchedule.Enabled = true;
                    }
                    else
                        btnAddDayPeriodToSchedule.Enabled = true;
                }
            }
        }

        private async void clbScheduleDayExceptionGroupIdList_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnAddDayExceptionGroupToSchedule.Enabled = false;
            btnRemoveDayExceptionGroupFromSchedule.Enabled = false;

            var clb = sender as CheckedListBox;
            if (clb != null && clb.SelectedItem != null)
            {
                var id = clb.SelectedItem as string;
                var dayExceptionGroup = await GetDayExceptionGroupFromDSR(id);
                FillListBox(dayExceptionGroup.dayExceptionIds, ref lbScheduleDayExceptionGroupDayExceptions);
                if (dayExceptionGroup != null && _selectedSchedule != null)
                {
                    if (_selectedSchedule.dayExceptionGroupIds != null)
                    {
                        if (_selectedSchedule.dayExceptionGroupIds.Contains(dayExceptionGroup.id))
                            btnRemoveDayExceptionGroupFromSchedule.Enabled = true;
                        else
                            btnAddDayExceptionGroupToSchedule.Enabled = true;
                    }
                    else
                        btnAddDayExceptionGroupToSchedule.Enabled = true;
                }
            }
        }

        private async void clbDayExceptionGroupsDayExceptionIdList_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnAddDayExceptionToDayExceptionGroup.Enabled = false;
            btnRemoveDayExceptionFromDayExceptionGroup.Enabled = false;

            var clb = sender as CheckedListBox;
            if (clb != null && clb.SelectedItem != null)
            {
                var id = clb.SelectedItem as string;
                var dayException = await GetDayExceptionFromDSR(id);
                ucDayExceptionViewControl.DayException = dayException;
                if (dayException != null && _selectedDayExceptionGroup != null)
                {
                    if (_selectedDayExceptionGroup.dayExceptionIds.Contains(dayException.id))
                        btnRemoveDayExceptionFromDayExceptionGroup.Enabled = true;
                    else
                        btnAddDayExceptionToDayExceptionGroup.Enabled = true;
                }
            }
        }

        private async void lbScheduleDayExceptionGroupDayExceptions_SelectedIndexChanged(object sender, EventArgs e)
        {
            var clb = sender as ListBox;
            if (clb != null)
            {
                var id = clb.SelectedItem as string;
                var dayException = await GetDayExceptionFromDSR(id);
                ucScheduleDayExceptionViewControl.DayException = dayException;
            }
        }

        private async void btnGetAccessPointModeIds_Click(object sender, EventArgs e)
        {
            var methodName = DsrAccessControlServiceMethodNames.GetAccessPointModeIds;
            try
            {
                var uuid = _dsrAccessControlProxy.CreateAccessControlServiceDsrUuid();

                var ids = await _dsrAccessControlProxy.GetAccessPointModeIdsAsync();

                FillComboBox(ids, ref cbAccessPointModeIdList);

                var sb = new StringBuilder();
                sb.Append(methodName);
                foreach (var id in ids)
                {
                    List<Guid> guidList = new List<Guid>();
                    guidList.Add(new Guid(id));
                    var accessPointModes = await _dsrAccessControlProxy.FindAccessPointModesAsync(guidList);

                    sb.Append(
                        string.Format("\n\tAccessPointModeId:{0}", id));
                }

                LogInformation(sb.ToString());
            }
            catch (Exception ex)
            {
                Log(methodName, ex);
            }
        }

        private async void cbAccessPointModeIdList_SelectedIndexChanged(object sender, EventArgs e)
        {
            var methodName = DsrAccessControlServiceMethodNames.FindAccessPointModes;
            try
            {
                SetCheckedForAllItems(ref clbAccessPointModeAccessPointList, false);
                var uuid = _dsrAccessControlProxy.CreateAccessControlServiceDsrUuid();
                string id = cbAccessPointModeIdList.SelectedItem.ToString();
                var idGuid = new Guid(id);
                if (idGuid != Guid.Empty)
                {
                    var accessPointMode = await GetAccessPointModeFromDSR(idGuid);

                    cbAccessPointModeType.SelectedItem = accessPointMode.accessPointModeType;
                    cbAccessPointModeSchedulesList.SelectedItem = accessPointMode.scheduleId;

                    SetAccessPointChecksById(accessPointMode.accessPointIds, ref clbAccessPointModeAccessPointList);
                }
                var sb = new StringBuilder();
                sb.Append(methodName);

                LogInformation(sb.ToString());
            }
            catch (Exception ex)
            {
                Log(methodName, ex);
            }
        }

        private void SetAccessPointChecksById(string[] accessPointIds, ref CheckedListBox checkedListBox)
        {
            foreach (var apId in accessPointIds)
            {
                for (int x = 0; x < checkedListBox.Items.Count; x++)
                {
                    var accessPoint = checkedListBox.Items[x] as GCS.AssaAbloyDSR.DSRManagementService.AccessPoint;
                    if (accessPoint != null)
                    {
                        if (accessPoint.id == apId)
                        {
                            checkedListBox.SetItemChecked(x, true);
                            break;
                        }
                    }
                }
            }
        }

        private void SetCheckedListBoxChecks(string[] ids, ref CheckedListBox checkedListBox)
        {
            foreach (var id in ids)
            {
                for (int x = 0; x < checkedListBox.Items.Count; x++)
                {
                    if (id == checkedListBox.Items[x] as string)
                    {
                        checkedListBox.SetItemChecked(x, true);
                        break;
                    }
                }
            }
        }

        private async void btnAddAccessPointMode_Click(object sender, EventArgs e)
        {
            var methodName = DsrAccessControlServiceMethodNames.AddAccessPointMode;
            try
            {
                var uuid = _dsrAccessControlProxy.CreateAccessControlServiceDsrUuid();

                var accessPointMode = GetAccessPointModeFromFormData();

                accessPointMode.id = Guid.NewGuid().ToString(); // make up a new Id value
                var id = await _dsrAccessControlProxy.AddAccessPointModeAsync(accessPointMode, null);

                cbAccessPointModeIdList.Items.Add(id);

                cbAccessPointModeIdList.SelectedItem = id;
                var sb = new StringBuilder();
                sb.Append(methodName);

                LogInformation(sb.ToString());
            }
            catch (Exception ex)
            {
                Log(methodName, ex);
            }
        }

        private AccessPointMode GetAccessPointModeFromFormData()
        {
            var accessPointMode = new AccessPointMode();

            accessPointMode.accessPointModeType = (AccessPointModeType) cbAccessPointModeType.SelectedItem;
            accessPointMode.scheduleId = cbAccessPointModeSchedulesList.SelectedItem as string;
            var apIds = new List<string>();
            foreach (var ap in clbAccessPointModeAccessPointList.CheckedItems)
            {
                var accessPoint = ap as GCS.AssaAbloyDSR.DSRManagementService.AccessPoint;
                if (accessPoint != null)
                    apIds.Add(accessPoint.id);
            }
            accessPointMode.accessPointIds = apIds.ToArray();
            return accessPointMode;
        }

        private async void btnModifyAccessPointMode_Click(object sender, EventArgs e)
        {
            var methodName = DsrAccessControlServiceMethodNames.ModifyAccessPointMode;
            try
            {
                string id = cbAccessPointModeIdList.SelectedItem.ToString();
                var idGuid = new Guid(id);
                if (idGuid != Guid.Empty)
                {
                    var uuid = _dsrAccessControlProxy.CreateAccessControlServiceDsrUuid();

                    var accessPointMode = GetAccessPointModeFromFormData();
                    accessPointMode.id = id;
                    var ret = await _dsrAccessControlProxy.ModifyAccessPointModeAsync(accessPointMode, null);
                }
                var sb = new StringBuilder();
                sb.Append(methodName);

                LogInformation(sb.ToString());
            }
            catch (Exception ex)
            {
                Log(methodName, ex);
            }
        }

        private async void btnRemoveAccessPointMode_Click(object sender, EventArgs e)
        {
            var methodName = DsrAccessControlServiceMethodNames.RemoveAccessPointMode;
            try
            {
                var uuid = _dsrAccessControlProxy.CreateAccessControlServiceDsrUuid();
                string id = cbAccessPointModeIdList.SelectedItem.ToString();
                var idGuid = new Guid(id);
                if (idGuid != Guid.Empty)
                {
                    await _dsrAccessControlProxy.RemoveAccessPointModeAsync(idGuid, null);
                }
                var sb = new StringBuilder();
                sb.Append(methodName);

                LogInformation(sb.ToString());
                btnGetAccessPointModeIds_Click(null, null);
            }
            catch (Exception ex)
            {
                Log(methodName, ex);
            }
        }

        private async void btnGetAuthorizationIds_Click(object sender, EventArgs e)
        {
            var methodName = DsrAccessControlServiceMethodNames.GetAuthorizationIds;
            try
            {
                var ids =
                    await _dsrAccessControlProxy.GetAuthorizationIdsAsync();
                FillComboBox(ids, ref cbAuthorizationIdList);

                var sb = new StringBuilder();
                sb.Append(methodName);
                foreach (var authorizationId in ids)
                {
                    sb.Append(
                        string.Format(
                            "\n\tAuthorizationId:{0}", authorizationId));
                }
                LogInformation(sb.ToString());
            }
            catch (Exception ex)
            {
                Log(methodName, ex);
            }
        }

        private async void cbAuthorizationIdList_SelectedIndexChanged(object sender, EventArgs e)
        {
            var methodName = DsrAccessControlServiceMethodNames.FindAuthorizations;
            try
            {
                btnaddUsersToAuthorization.Enabled = false;
                btnremoveUsersFromAuthorization.Enabled = false;
                btnaddAccessPointsToAuthorization.Enabled = false;
                btnremoveAccessPointsFromAuthorization.Enabled = false;
                btnSetNewScheduleInAuthorization.Enabled = false;
                btnSetAuthorizationTypeForAuthorization.Enabled = false;

                SetCheckedForAllItems(ref clbAuthorizationAuthorizeUsers, false);
                SetCheckedForAllItems(ref clbAuthorizationAuthorizeAccessPoints, false);

                var uuid = _dsrAccessControlProxy.CreateAccessControlServiceDsrUuid();
                string id = cbAuthorizationIdList.SelectedItem.ToString();
                var idGuid = new Guid(id);
                if (idGuid != Guid.Empty)
                {
                    var ids = new List<Guid>();
                    ids.Add(idGuid);
                    var authorizations = await _dsrAccessControlProxy.FindAuthorizationsAsync(ids);
                    var authorization = authorizations.FirstOrDefault();

                    if (authorization.authorizationType.Length > 0)
                        cbAuthorizationAuthorizationType.SelectedItem = authorization.authorizationType[0];
                    cbAuthorizationAuthorizationSchedule.SelectedItem = authorization.scheduleId;
                    SetAccessPointChecksById(authorization.accessPointId, ref clbAuthorizationAuthorizeAccessPoints);
                    if (authorization.userId != null)
                        SetCheckedListBoxChecks(authorization.userId, ref clbAuthorizationAuthorizeUsers);
                    txtUseCount.Text = authorization.useCount.ToString();
                    if (authorization.useCountSpecified == false)
                        txtUseCount.Text = "0";
                }
                var sb = new StringBuilder();
                sb.Append(methodName);

                LogInformation(sb.ToString());
            }
            catch (Exception ex)
            {
                Log(methodName, ex);
            }
        }

        private async void btnAddAuthorization_Click(object sender, EventArgs e)
        {
            var methodName = DsrAccessControlServiceMethodNames.AddAuthorization;
            try
            {
                var uuid = _dsrAccessControlProxy.CreateAccessControlServiceDsrUuid();

                var authorization = GetAuthorizationFromFormData();

                authorization.id = Guid.NewGuid().ToString(); // make up a new Id value
                var id = await _dsrAccessControlProxy.AddAuthorizationAsync(authorization, null);

                cbAuthorizationIdList.Items.Add(id);

                cbAuthorizationIdList.SelectedItem = id;
                var sb = new StringBuilder();
                sb.Append(methodName);

                LogInformation(sb.ToString());
            }
            catch (Exception ex)
            {
                Log(methodName, ex);
            }
        }

        private Authorization GetAuthorizationFromFormData()
        {
            var authorization = new Authorization();

            var authorizationTypeList = new List<AuthorizationType>();
            authorizationTypeList.Add((AuthorizationType) cbAuthorizationAuthorizationType.SelectedItem);
            authorization.authorizationType = authorizationTypeList.ToArray();
            authorization.scheduleId = cbAuthorizationAuthorizationSchedule.SelectedItem as string;

            authorization.userId = GetCheckedItemsAsStringArray(ref clbAuthorizationAuthorizeUsers);
            authorization.accessPointId =
                GetCheckedAccessPointsIdsAsStringArray(ref clbAuthorizationAuthorizeAccessPoints);
            authorization.useCountSpecified = false;
            authorization.useCount = 0;
            int useCount = 0;
            if (int.TryParse(txtUseCount.Text, out useCount))
            {
                authorization.useCount = useCount;
                if (useCount > 0)
                    authorization.useCountSpecified = true;
            }

            return authorization;
        }

        private async void btnModifyAuthorization_Click(object sender, EventArgs e)
        {
            var methodName = DsrAccessControlServiceMethodNames.ModifyAuthorization;
            try
            {
                string id = cbAuthorizationIdList.SelectedItem.ToString();
                var idGuid = new Guid(id);
                if (idGuid != Guid.Empty)
                {
                    var uuid = _dsrAccessControlProxy.CreateAccessControlServiceDsrUuid();

                    var authorization = GetAuthorizationFromFormData();
                    authorization.id = id;
                    var ret = await _dsrAccessControlProxy.ModifyAuthorizationAsync(authorization, null);
                }
                var sb = new StringBuilder();
                sb.Append(methodName);

                LogInformation(sb.ToString());
            }
            catch (Exception ex)
            {
                Log(methodName, ex);
            }
        }

        private async void btnRemoveAuthorization_Click(object sender, EventArgs e)
        {
            var methodName = DsrAccessControlServiceMethodNames.RemoveAuthorization;
            try
            {
                var uuid = _dsrAccessControlProxy.CreateAccessControlServiceDsrUuid();
                string id = cbAuthorizationIdList.SelectedItem.ToString();
                var idGuid = new Guid(id);
                if (idGuid != Guid.Empty)
                {
                    await _dsrAccessControlProxy.RemoveAuthorizationAsync(idGuid, null);
                }
                var sb = new StringBuilder();
                sb.Append(methodName);

                LogInformation(sb.ToString());
                btnGetAuthorizationIds_Click(null, null);
            }
            catch (Exception ex)
            {
                Log(methodName, ex);
            }
        }

        private async void btnACGetNewLogsRepeat_Click(object sender, EventArgs e)
        {
            var methodName = DsrAccessControlServiceMethodNames.GetNewLogs;
            try
            {
                if (SelectedAccessControlTabAccessPoint != null)
                {
                    bool bDoAgain = true;
                    while (bDoAgain)
                    {
                        var data = await _dsrAccessControlProxy.GetNewLogsAsync(SelectedAccessControlTabAccessPoint.id);
                        if (data != null)
                        {
                            if (data.Count() == 0)
                                bDoAgain = false;

                            var sb = new StringBuilder();
                            sb.Append(methodName);

                            foreach (var logEntry in data)
                            {
                                sb.Append(
                                    string.Format(
                                        "\n\tTimeStamp:{0}, Code:{1}, Family:{2}, origin.logOriginType:{3}, origin.originId:{4}, requestId:{5}",
                                        logEntry.timeStamp,
                                        logEntry.code,
                                        logEntry.family,
                                        logEntry.origin.logOriginType,
                                        logEntry.origin.originId,
                                        logEntry.requestId.requestId));
                                foreach (var log in logEntry.logData)
                                {
                                    sb.Append(
                                        string.Format(
                                            "\n\t\tName:{0}, stringValue:{1}, intValueSpecified:{2}, intValue:{3}",
                                            log.name,
                                            log.value.stringValue,
                                            log.value.intValueSpecified,
                                            log.value.intValue));
                                }
                            }
                            LogInformation(sb.ToString());
                        }
                        else
                            bDoAgain = false;
                    }
                }
            }
            catch (Exception ex)
            {
                Log(methodName, ex);
            }
        }

        private async void btnACGetNewLogsRepeatForDSR_Click(object sender, EventArgs e)
        {
            var methodName = DsrAccessControlServiceMethodNames.GetNewLogs;
            try
            {
                bool bDoAgain = true;
                while (bDoAgain)
                {
                    var data = await _dsrAccessControlProxy.GetNewLogsAsync(string.Empty);
                    if (data != null)
                    {
                        if (data.Count() == 0)
                            bDoAgain = false;

                        var sb = new StringBuilder();
                        sb.Append(methodName);

                        foreach (var logEntry in data)
                        {
                            sb.Append(
                                string.Format(
                                    "\n\tTimeStamp:{0}, Code:{1}, Family:{2}, origin.logOriginType:{3}, origin.originId:{4}, requestId:{5}",
                                    logEntry.timeStamp,
                                    logEntry.code,
                                    logEntry.family,
                                    logEntry.origin.logOriginType,
                                    logEntry.origin.originId,
                                    logEntry.requestId.requestId));
                            foreach (var log in logEntry.logData)
                            {
                                sb.Append(
                                    string.Format(
                                        "\n\t\tName:{0}, stringValue:{1}, intValueSpecified:{2}, intValue:{3}",
                                        log.name,
                                        log.value.stringValue,
                                        log.value.intValueSpecified,
                                        log.value.intValue));
                            }
                        }
                        LogInformation(sb.ToString());
                    }
                    else
                        bDoAgain = false;
                }
            }
            catch (Exception ex)
            {
                Log(methodName, ex);
            }
        }

        private async void btnaddUsersToAuthorization_Click(object sender, EventArgs e)
        {
            var methodName = DsrAccessControlServiceMethodNames.AddUsersToAuthorization;
            try
            {
                var uuid = _dsrAccessControlProxy.CreateAccessControlServiceDsrUuid();
                string id = cbAuthorizationIdList.SelectedItem.ToString();
                var idGuid = new Guid(id);
                if (idGuid != Guid.Empty)
                {
                    var ids = new List<Guid>();
                    ids.Add(idGuid);
                    var authorizations = await _dsrAccessControlProxy.FindAuthorizationsAsync(ids);
                    var authorization = authorizations.First();
                    if (authorization != null)
                    {
                        var userIds = new List<Guid>();
                        foreach (var userId in clbAuthorizationAuthorizeUsers.SelectedItems)
                        {
                            userIds.Add(new Guid((string) userId));
                        }
                        var result = await _dsrAccessControlProxy.AddUsersToAuthorizationAsync(userIds, idGuid, null);
                    }
                }
                var sb = new StringBuilder();
                sb.Append(methodName);

                LogInformation(sb.ToString());
            }
            catch (Exception ex)
            {
                Log(methodName, ex);
            }
        }

        private async void btnremoveUsersFromAuthorization_Click(object sender, EventArgs e)
        {
            var methodName = DsrAccessControlServiceMethodNames.RemoveUsersFromAuthorization;
            try
            {
                var uuid = _dsrAccessControlProxy.CreateAccessControlServiceDsrUuid();
                string id = cbAuthorizationIdList.SelectedItem.ToString();
                var idGuid = new Guid(id);
                if (idGuid != Guid.Empty)
                {
                    var ids = new List<Guid>();
                    ids.Add(idGuid);
                    var authorizations = await _dsrAccessControlProxy.FindAuthorizationsAsync(ids);
                    var authorization = authorizations.First();
                    if (authorization != null)
                    {
                        var userIds = new List<Guid>();
                        foreach (var userId in clbAuthorizationAuthorizeUsers.SelectedItems)
                        {
                            userIds.Add(new Guid((string) userId));
                        }
                        var result = await _dsrAccessControlProxy.RemoveUsersFromAuthorizationAsync(userIds, idGuid,
                            null);
                    }
                }
                var sb = new StringBuilder();
                sb.Append(methodName);

                LogInformation(sb.ToString());
            }
            catch (Exception ex)
            {
                Log(methodName, ex);
            }
        }

        private async void btnaddAccessPointsToAuthorization_Click(object sender, EventArgs e)
        {
            var methodName = DsrAccessControlServiceMethodNames.AddAccessPointsToAuthorization;
            try
            {
                var uuid = _dsrAccessControlProxy.CreateAccessControlServiceDsrUuid();

                string id = cbAuthorizationIdList.SelectedItem.ToString();
                var idGuid = new Guid(id);
                if (idGuid != Guid.Empty)
                {
                    var ids = new List<Guid>();
                    ids.Add(idGuid);
                    var authorizations = await _dsrAccessControlProxy.FindAuthorizationsAsync(ids);
                    var authorization = authorizations.First();
                    if (authorization != null)
                    {
                        var apIds = new List<string>();
                        foreach (var apId in clbAuthorizationAuthorizeAccessPoints.SelectedItems)
                        {
                            apIds.Add((string) apId);
                        }
                        var result = await _dsrAccessControlProxy.AddAccessPointsToAuthorizationAsync(apIds, idGuid,
                            null);
                    }
                }
                var sb = new StringBuilder();
                sb.Append(methodName);

                LogInformation(sb.ToString());
            }
            catch (Exception ex)
            {
                Log(methodName, ex);
            }
        }

        private async void btnremoveAccessPointsFromAuthorization_Click(object sender, EventArgs e)
        {
            var methodName = DsrAccessControlServiceMethodNames.RemoveAccessPointsFromAuthorization;
            try
            {
                var uuid = _dsrAccessControlProxy.CreateAccessControlServiceDsrUuid();

                string id = cbAuthorizationIdList.SelectedItem.ToString();
                var idGuid = new Guid(id);
                if (idGuid != Guid.Empty)
                {
                    var ids = new List<Guid>();
                    ids.Add(idGuid);
                    var authorizations = await _dsrAccessControlProxy.FindAuthorizationsAsync(ids);
                    var authorization = authorizations.First();
                    if (authorization != null)
                    {
                        var apIds = new List<string>();
                        foreach (var apId in clbAuthorizationAuthorizeAccessPoints.SelectedItems)
                        {
                            apIds.Add((string) apId);
                        }
                        var result = await _dsrAccessControlProxy.RemoveAccessPointsFromAuthorizationAsync(apIds, idGuid,
                            null);
                    }
                }
                var sb = new StringBuilder();
                sb.Append(methodName);

                LogInformation(sb.ToString());
            }
            catch (Exception ex)
            {
                Log(methodName, ex);
            }
        }

        private async void btnSetAuthorizationTypeForAuthorization_Click(object sender, EventArgs e)
        {
            var methodName = DsrAccessControlServiceMethodNames.SetAuthorizationTypeForAuthorization;
            try
            {
                var uuid = _dsrAccessControlProxy.CreateAccessControlServiceDsrUuid();
                string id = cbAuthorizationIdList.SelectedItem.ToString();
                var idGuid = new Guid(id);
                if (idGuid != Guid.Empty)
                {
                    var ids = new List<Guid>();
                    ids.Add(idGuid);
                    var authorizations = await _dsrAccessControlProxy.FindAuthorizationsAsync(ids);
                    var authorization = authorizations.First();
                    if (authorization != null)
                    {
                        var authorizationType = (AuthorizationType) cbAuthorizationAuthorizationType.SelectedItem;
                        var result = await _dsrAccessControlProxy.SetAuthorizationTypeForAuthorizationAsync(idGuid,
                            authorizationType, null);
                    }
                }
                var sb = new StringBuilder();
                sb.Append(methodName);

                LogInformation(sb.ToString());
            }
            catch (Exception ex)
            {
                Log(methodName, ex);
            }
        }

        private async void btnSetNewScheduleInAuthorization_Click(object sender, EventArgs e)
        {
            var methodName = DsrAccessControlServiceMethodNames.SetNewScheduleInAuthorization;
            try
            {
                var uuid = _dsrAccessControlProxy.CreateAccessControlServiceDsrUuid();
                string id = cbAuthorizationIdList.SelectedItem.ToString();
                var idGuid = new Guid(id);
                if (idGuid != Guid.Empty)
                {
                    var ids = new List<Guid>();
                    ids.Add(idGuid);
                    var authorizations = await _dsrAccessControlProxy.FindAuthorizationsAsync(ids);
                    var authorization = authorizations.First();
                    if (authorization != null)
                    {
                        var scheduleId = cbAuthorizationAuthorizationSchedule.SelectedItem as string;
                        var result =
                            await _dsrAccessControlProxy.SetNewScheduleInAuthorizationAsync(new Guid(scheduleId), idGuid,
                                null);
                    }
                }
                var sb = new StringBuilder();
                sb.Append(methodName);

                LogInformation(sb.ToString());
            }
            catch (Exception ex)
            {
                Log(methodName, ex);
            }
        }

        private void clbAuthorizationAuthorizeUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnaddUsersToAuthorization.Enabled = false;
            btnremoveUsersFromAuthorization.Enabled = false;
            if (cbAuthorizationIdList.SelectedItem == null)
                return;

            string id = cbAuthorizationIdList.SelectedItem.ToString();
            var idGuid = new Guid(id);
            if (idGuid != Guid.Empty)
            {
                if (clbAuthorizationAuthorizeUsers.SelectedItems.Count > 0)
                {
                    btnaddUsersToAuthorization.Enabled = true;
                    btnremoveUsersFromAuthorization.Enabled = true;
                }
            }
        }

        private void clbAuthorizationAuthorizeAccessPoints_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnaddUsersToAuthorization.Enabled = false;
            btnremoveUsersFromAuthorization.Enabled = false;
            if (cbAuthorizationIdList.SelectedItem == null)
                return;

            string id = cbAuthorizationIdList.SelectedItem.ToString();
            var idGuid = new Guid(id);
            if (idGuid != Guid.Empty)
            {
                if (clbAuthorizationAuthorizeAccessPoints.SelectedItems.Count > 0)
                {
                    btnaddAccessPointsToAuthorization.Enabled = true;
                    btnremoveAccessPointsFromAuthorization.Enabled = true;
                }
            }
        }

        private void cbAuthorizationAuthorizationType_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnSetAuthorizationTypeForAuthorization.Enabled = false;
            if (cbAuthorizationIdList.SelectedItem == null)
                return;
            string id = cbAuthorizationIdList.SelectedItem.ToString();
            var idGuid = new Guid(id);
            if (idGuid != Guid.Empty)
            {
                if (cbAuthorizationAuthorizationType.SelectedItem != null)
                {
                    btnSetAuthorizationTypeForAuthorization.Enabled = true;
                }
            }
        }

        private void cbAuthorizationAuthorizationSchedule_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnSetNewScheduleInAuthorization.Enabled = false;
            if (cbAuthorizationIdList.SelectedItem == null)
                return;
            string id = cbAuthorizationIdList.SelectedItem.ToString();
            var idGuid = new Guid(id);
            if (idGuid != Guid.Empty)
            {
                if (cbAuthorizationAuthorizationSchedule.SelectedItem != null)
                {
                    btnSetNewScheduleInAuthorization.Enabled = true;
                }
            }
        }

        private async void btnSetUnlockTime_Click(object sender, EventArgs e)
        {
            var methodName = DsrAccessControlServiceMethodNames.DeviceSpecificCommand;
            try
            {
                if (SelectedAccessControlTabAccessPoint != null)
                {
                    byte seconds;
                    if (byte.TryParse(txtUnlockTime.Text, out seconds) == false)
                        seconds = 5;
                    var command =
                        DeviceSpecificCommandTypeHelpers.GetSetConfigParamCommand<byte>(
                            SetConfigParamU8Commands.StrikeUnlockDurationSeconds, seconds);
                    var data =
                        await _dsrAccessControlProxy.ExecuteDeviceSpecificCommandAsync(
                            SelectedAccessControlTabAccessPoint.id, command);
                    if (data != null)
                    {
                        var sb = new StringBuilder();
                        sb.Append(methodName);
                        LogInformation(sb.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                Log(methodName, ex);
            }
        }

        private async void btnSetFilters_Click(object sender, EventArgs e)
        {
            var methodName = DsrAccessControlServiceMethodNames.DeviceSpecificCommand;
            try
            {
                if (SelectedAccessControlTabAccessPoint != null)
                {
                    var filters = new List<string>();
                    filters.Add(Filters.ClearAllFilters);
                    //filters.Add(Filters.LOCKOUTBEGIN);

                    var command =
                        DeviceSpecificCommandTypeHelpers.GetSetFiltersCommand(FiltersCommand.FilterTarget.Reporting,
                            filters.ToArray());
                    var data =
                        await _dsrAccessControlProxy.ExecuteDeviceSpecificCommandAsync(
                            SelectedAccessControlTabAccessPoint.id, command);
                    if (data != null)
                    {
                        var sb = new StringBuilder();
                        sb.Append(methodName);
                        LogInformation(sb.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                Log(methodName, ex);
            }
        }

        private async void btnSetAlarms_Click(object sender, EventArgs e)
        {
            var methodName = DsrAccessControlServiceMethodNames.DeviceSpecificCommand;
            try
            {
                if (SelectedAccessControlTabAccessPoint != null)
                {
                    // Spin through all items in first list and see if any others are checked
                    for (int x = 0; x < clbSecuredModeAlarms.Items.Count; x++)
                    {
                        Alarm alarmToSend = new Alarm();
                        Alarm securedAlarm = clbSecuredModeAlarms.Items[x] as Alarm;
                        alarmToSend.Type = securedAlarm.Type;
                        if (clbSecuredModeAlarms.CheckedItems.Contains(securedAlarm))
                        {
                            alarmToSend.Mode |= securedAlarm.Mode;
                        }

                        Alarm passageAlarm = clbPassageModeAlarms.Items[x] as Alarm;
                        if (clbPassageModeAlarms.CheckedItems.Contains(passageAlarm))
                        {
                            alarmToSend.Mode |= passageAlarm.Mode;
                        }

                        Alarm rxHeldAlarm = clbRXHeldModeAlarms.Items[x] as Alarm;
                        if (clbRXHeldModeAlarms.CheckedItems.Contains(rxHeldAlarm))
                        {
                            alarmToSend.Mode |= rxHeldAlarm.Mode;
                        }

                        var command = DeviceSpecificCommandTypeHelpers.GetAlarmConfigCommand(alarmToSend);
                        var data =
                            await _dsrAccessControlProxy.ExecuteDeviceSpecificCommandAsync(
                                SelectedAccessControlTabAccessPoint.id, command);
                        if (data != null)
                        {
                            var sb = new StringBuilder();
                            sb.Append(methodName);
                            LogInformation(sb.ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Log(methodName, ex);
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
        }

        private void cbAccessPointScheduler_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedItem = this.cbAccessPointScheduler.SelectedItem as SchedulingAlgorithm;
            if (selectedItem == null)
                return;

            switch (selectedItem.Type)
            {
                case SchedulingAlgorithm.ScheduleType.AlwaysOn:
                    break;
                case SchedulingAlgorithm.ScheduleType.Simple:
                    break;
                case SchedulingAlgorithm.ScheduleType.DayOfMonth:
                    break;
                case SchedulingAlgorithm.ScheduleType.DayOfWeek:
                    break;
                case SchedulingAlgorithm.ScheduleType.CommUser:
                    break;
                case SchedulingAlgorithm.ScheduleType.HourOfDay:
                    break;
                case SchedulingAlgorithm.ScheduleType.AlwaysOff:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private async void btnSetAccessPointSchedulerSimple_Click(object sender, EventArgs e)
        {
            var methodName = DsrAccessControlServiceMethodNames.DeviceSpecificCommand;
            try
            {
                if (SelectedAccessControlTabAccessPoint != null)
                {
                    UInt16 minutes;
                    if (UInt16.TryParse(this.txtAccessPointSimpleConnectMinutes.Text, out minutes) == false)
                        minutes = 60;
                    var command =
                        DeviceSpecificCommandTypeHelpers.GetSetConfigParamCommand<byte>(
                            SetConfigParamU8Commands.SchedulingAlgorithm, (byte) SchedulingAlgorithm.ScheduleType.Simple);
                    var data =
                        await _dsrAccessControlProxy.ExecuteDeviceSpecificCommandAsync(
                            SelectedAccessControlTabAccessPoint.id, command);
                    var command1 =
                        DeviceSpecificCommandTypeHelpers.GetSetConfigParamCommand<UInt16>(
                            SetConfigParamU16Commands.PeriodSchedulerAwakens, minutes);
                    var data1 =
                        await _dsrAccessControlProxy.ExecuteDeviceSpecificCommandAsync(
                            SelectedAccessControlTabAccessPoint.id, command1);
                    if (data != null && data1 != null)
                    {
                        var sb = new StringBuilder();
                        sb.Append(methodName);
                        LogInformation(sb.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                Log(methodName, ex);
            }
        }

        private void btnToggleAllUsersAuthorization_Click(object sender, EventArgs e)
        {
            bool c = false;
            if( clbAuthorizationAuthorizeUsers.Items.Count > 0)
                c = clbAuthorizationAuthorizeUsers.GetItemChecked(0);
            c = !c;
            int incCount;
            if( int.TryParse(txtToggleAuthIncCount.Text, out incCount) == false)
                incCount = 1;
            for (int i = 0; i < clbAuthorizationAuthorizeUsers.Items.Count; i+=incCount)
                clbAuthorizationAuthorizeUsers.SetItemChecked(i, c);
        }

        private void btnToggleAllAccessPointsAuthorization_Click(object sender, EventArgs e)
        {
            bool c = false;
            if( clbAuthorizationAuthorizeAccessPoints.Items.Count > 0)
                c = clbAuthorizationAuthorizeAccessPoints.GetItemChecked(0);
            c = !c;

            int incCount;
            if( int.TryParse(txtToggleAuthIncCount.Text, out incCount) == false)
                incCount = 1;

            for (int i = 0; i < clbAuthorizationAuthorizeAccessPoints.Items.Count; i+=incCount)
                clbAuthorizationAuthorizeAccessPoints.SetItemChecked(i, c);
        }

        private async void btnRemoveAllAccessPoints_Click(object sender, EventArgs e)
        {

            try
            {
                int count = cbAllAccessPoints.Items.Count;
               foreach (var i in cbAllAccessPoints.Items)
                {
                    var ap = i as AssaAbloyDSR.DSRManagementService.AccessPoint;
                    if (ap != null)
                    {
                        var methodName = DsrManagementServiceMethodNames.RemoveAccessPoint;
                        try
                        {
                            var o = await _dsrManagementProxy.RemoveAccessPointAsync(ap.id);
                            count--;
                            lblAccessPointCount.Text = count.ToString();

                            //var sb = new StringBuilder();
                            //sb.Append(methodName);
                            //LogInformation(sb.ToString());
                        }
                        catch (Exception ex)
                        {
                            Log(methodName, ex);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Log("GetAllAccessPointsAsync", ex);
            }
        }

        private void txtCallbackAddress_TextChanged(object sender, EventArgs e)
        {
            SaveSettings();
            CreateDsrConnectionParameters();
        }

        private void txtCallbackPort_TextChanged(object sender, EventArgs e)
        {
            SaveSettings();
             CreateDsrConnectionParameters();
       }

        private void chkUseEncryption_Click(object sender, EventArgs e)
        {
            SaveSettings();
            CreateDsrConnectionParameters();
        }

        private void SaveSettings()
        {

            Properties.Settings.Default.DSRIPAddress = txtDSRIpAddress.Text;
            Properties.Settings.Default.CallbackAddress = txtCallbackAddress.Text;
            Properties.Settings.Default.CallbackPort = txtCallbackPort.Text;
            Properties.Settings.Default.UseHttps = chkUseEncryption.Checked;
           
        }

        private void btnFindUserByCardNumbers_Click(object sender, EventArgs e)
        {
            try
            {
                var fc = txtCredentialFacilityCode.Text;
                var id = txtCredentialIntegerValue.Text;
                var cf = cbCredentialFormats.SelectedItem;

                for (int x = 0; x < cbUserIds.Items.Count; x++)
                {
                    cbUserIds.SelectedIndex = x;
                    cbUserIds_SelectedIndexChanged(null, null);
                    if (txtCredentialFacilityCode.Text == fc && txtCredentialIntegerValue.Text == id)
                    {
                        break;
                    }
                }

            }
            catch (Exception ex)
            { 

            }

        }
    }
}