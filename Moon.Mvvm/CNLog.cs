using NLog;
using NLog.Config;
using NLog.Targets;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Moon.Mvvm
{
    public class CNLog
    {
        /// <summary>
        ///  使用程式碼配置 NLog
        /// </summary>
        public static void InitConfig()
        {
            var config = new LoggingConfiguration();

            // 文件目標
            var fileTarget = new FileTarget("fileTarget")
            {
                FileName = "${basedir}/logs/Info.log",
                ArchiveAboveSize = 1048576,
                MaxArchiveFiles = 10,
                ArchiveEvery = FileArchivePeriod.Day,
                Layout = "${longDate}|${logger:padding=50:fixedLength=true}|${level:padding=5:fixedLength=true}||${message}"
            };
            config.AddTarget(fileTarget);
            config.LoggingRules.Add(new LoggingRule("*", NLog.LogLevel.Info, fileTarget));


            // 調試器目標
            var debuggerTarget = new DebuggerTarget("debugger")
            {
                Layout = "${time}|${logger:padding=50:fixedLength=true}|${level:padding=5:fixedLength=true}||${message}"
            };
            config.AddTarget(debuggerTarget);
            config.LoggingRules.Add(new LoggingRule("*", NLog.LogLevel.Debug, debuggerTarget));

            // 控制台目標
            var uiTarget = new UILogTarget
            {
                Name = "uiTarget",
                Layout = "${time}|${logger:padding=50:fixedLength=true}|${level:padding=5:fixedLength=true}||${message}"
            };
            config.AddTarget(uiTarget);
            config.AddRuleForAllLevels(uiTarget); // <== 最重要

            LogManager.Configuration = config;
        }

        /// <summary>
        /// 記錄 Debug 等級的日誌，自動捕獲呼叫類別
        /// </summary>
        /// <param name="message">日誌訊息</param>
        /// <param name="filePath">呼叫者的檔案路徑（自動填入）</param>
        /// <param name="memberName">呼叫者的成員名稱（自動填入）</param>
        /// <param name="lineNumber">呼叫者的行號（自動填入）</param>
        public static void Debug(string message,
            [CallerFilePath] string filePath = "",
            [CallerMemberName] string memberName = "",
            [CallerLineNumber] int lineNumber = 0)
        {
            // 使用 StackTrace 取得真正的呼叫類別
            var stackTrace = new StackTrace(1, false);
            var frame = stackTrace.GetFrame(0);
            var method = frame?.GetMethod();
            var declaringType = method?.DeclaringType;
            var className = declaringType?.Name ?? Path.GetFileNameWithoutExtension(filePath);

            var logger = LogManager.GetLogger(className);
            var fullMessage = $"[{memberName}:{lineNumber}] {message}";
            logger.Debug(fullMessage);
        }
    }

    public static class UILogBridge
    {
        public static SynchronizationContext? UISyncContext { get; set; }

        public static ObservableCollection<string> Logs { get; } = [];

        public static void AddLog(string message)
        {

            UISyncContext?.Post(_ =>
                {
                    Logs.Add(message);
                }, null);
        }
    }

    [Target("UILogTarget")]
    public sealed class UILogTarget : TargetWithLayout
    {
        protected override void Write(LogEventInfo logEvent)
        {
            if (logEvent.Level.Ordinal >= LogLevel.Debug.Ordinal)
            {
                string message = Layout.Render(logEvent);
                UILogBridge.AddLog(message);
            }
        }
    }
}
