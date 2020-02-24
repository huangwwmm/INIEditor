using System.ComponentModel;

namespace INIEditor.Eternity
{
    [Description("global_config.default.ini的用法是重命名为global_config.ini\r\n"
        + "目录结构应为 Assets/global_config.ini\r\n配置方法[组名]\r\n"
        + "每行一个配置项以第一个'='为分隔符 {key}={value}\r\n"
        + "注意不需要添加空格，空格会被包含在key和value中\r\n"
        + "不支持换行符制表符等，但是可以通过json等方式实现\r\n"
        + "';'开头的为注释行，空行会被忽略")]
    public class Config : BaseConfig
    {
        #region Server
        [Category("Server")
            , Description("微服URL 登录用")
            , DefaultValue("http://10.53.2.83:3001/")]
        public string MicroServerURL_Auth { get; set; }
        [Category("Server")
            , Description("微服URL 获取服务器列表用")
            , DefaultValue("http://10.53.2.83:3002/")]
        public string MicroServerURL_GetServerList { get; set; }
        [Category("Server")
            , Description("如果没有这个配置，则会从{MicroServerURL_GetServerList}获取服务器列表\r\n"
                + "填Json，示例：\r\n"
                + "{\"server_list\":[{\"id\":\"74\",\"gid\":\"HuangWM_Lan\",\"ip\":\"192.168.2.199\",\"port\":3724,\"name\":\"HuangWM_Lan\",\"open_flag\":true,\"status\":0,\"open_time\":\"2017-6-17-12-00-00\"}]}")
            , DefaultValue("")]
        public string DefaultServerList { get; set; }
        #endregion

        #region Login
        [Category("Login")
            , Description("游戏启动时，是否填写默认的用户名")
            , DefaultValue(false)]
        public bool EnableDefaultUsername { get; set; }
        [Category("Login")
            , Description("see{EnableDefaultUsername}")
            , DefaultValue(null)]
        public string DefaultUsername { get; set; }
        [Category("Login")
            , Description("第一次登录时是否显示协议面板")
            , DefaultValue(false)]
        public bool DisplayAgreementPanel { get; set; }
        [Category("Login")
            , Description("有这个配置时，刚进游戏时默认使用这个Server")
            , DefaultValue("")]
        public string DefaultLastLoginServer { get; set; }
        [Category("Login")
            , Description("进游戏直接登录，用来解决XboxOne平台手柄不能点击UI。使用这个配置需要满足以下条件\r\n"
                + "上次成功登录过或\r\n"
                + "\t{EnableDefaultUsername}=true\r\n"
                + "\t{DefaultUsername}不为空\r\n"
                + "\t{DisplayAgreementPanel}=false\r\n"
                + "\t{DefaultLastLoginServer}不为空")
            , DefaultValue(false)]
        public bool AutoLogin { get; set; }
        [Category("Login")
            , Description("每次登录都随机用户名")
            , DefaultValue(false)]
        public bool RandomUsername { get; set; }
        [Category("Login")
            , Description("创建角色界面自动创建角色\r\n"
                + "配合{AutoLogin}，{RandomUsername}一起用可以实现每次启动游戏都创建一个新的账号角色并自动进入游戏")
            , DefaultValue(false)]
        public bool AutoCreateRole { get; set; }
        #endregion

        #region Debug
        [Category("Debug")
          , Description("是否开启DebugPanel")
          , DefaultValue(true)]
        public bool EnableDebugPanel { get; set; }
        [Category("Debug")
           , Description("只在编辑器下生效，DebugPanel的类型：DebugPanel; EditorDebugPanel\r\n"
                + "打包后强制使用DebugPanel\r\n"
                + "EditorDebugPanel: 会在UnityEditor中打开一个EditorWindow\r\n"
                + "DebugPanel: 在游戏画面(Game视图)上显示一层DebugPanel\r\n"
                + "\tCtrl + Shift + Alt + D: 显示/隐藏DebugPanel\r\n"
                + "\tCtrl + Shift + Alt + U: 显示/隐藏空的UI界面(因为显示UI界面的时候才能用虚拟光标)")
           , DefaultValue(DebugPanelType.EditorDebugPanel)]
        public DebugPanelType DebugPanelType { get; set; }
        [Category("Debug")
           , Description("代码的Profiler(执行时间)，用来分析一段代码，在一段时间内的耗时。see CodeProfilerInstance.cs")
           , DefaultValue(false)]
        public bool EnableCodeProfiler { get; set; }
        [Category("Debug")
           , Description("把Log保存到文件，可以通过Scene窗口->Toolbar->Report Log按钮查看保存的文件\r\n"
                + "用于查看以前运行的Log，Log接收的Application.logMessageReceivedThreaded")
           , DefaultValue(false)]
        public bool EnableLogRecord { get; set; }
        [Category("Debug")
           , Description("开启后，自定义的LogConsole才会显示运行时的Log。{EnableLogRecord}记录的Log文件可以离线在这个窗口显示")
           , DefaultValue(true)]
        public bool EnableLogItems { get; set; }
        [Category("Debug")
           , Description("只在编辑器下生效，把LogItems保存到文件\r\n"
                + "相当于{EnableRecordLogItems} = !(Unity Console的Clear on Play) \r\n"
                + "最好用false，因为在游戏启动时读文件会堵塞主线程")
           , DefaultValue(false)]
        public bool EnableRecordLogItems { get; set; }
        [Category("Debug")
           , Description("see RemoteDebug.cs\r\n"
                + "远程调试用的Server的地址，{EnableDebugPanel}=true时这个选项才能被使用\r\n"
                + "这个地址是运行UnityEditor的设备IP地址")
           , DefaultValue("192.168.2.199")]
        public string RemoteDebugAddress { get; set; }
        [Category("Debug")
           , Description("远程调试用的Server的端口，{EnableDebugPanel}=true时这个选项才能被使用\r\n"
                + "global_config文件在UnityEditor下和打包后的游戏目录中个有一份，要保证这两个文件的端口设置相同")
           , DefaultValue(13589)]
        public int RemoteDebugPort { get; set; }
        [Category("Debug")
           , Description("有些平台上Screen.dpi返回结果是0，为了让DebugPanel能正常工作加的这条设置。DPI会影响DebugPanel整体大小")
           , DefaultValue(80.0f)]
        public float DebugPanelScreenDPI { get; set; }
        [Category("Debug")
           , Description("GM指令 格式：在DebugPanel上的显示名字:指令|DisplayName:GMItem|DisplayName:GMItem|……")
           , DefaultValue("Add Bandit:addnpc 20101|Add Boss:addnpc 20107")]
        public string GMItems { get; set; }
        [Category("Debug")
           , Description("在DebugPanel上显示的 nearClipPlanes1:near2:……|farClipPlanes1:far2:……\r\n"
                + "用于在运行时通过DebugPanel修改相机的参数")
           , DefaultValue("0.1:0.2:0.5|1000:3000:5000:30000:80000:200000")]
        public string MainCameraLens { get; set; }
        [Category("Debug")
           , Description("see TrackCaptureManager.cs\r\n"
                 + "是否启用Track")
           , DefaultValue(false)]
        public bool EnableTrack { get; set; }
        #endregion

        #region Renderer
        [Category("Renderer")
            , Description("NOTE：动态分辨率只在XboxOne平台生效，且需要\r\n"
                + "\t应用动态分辨率的相机要开启Camera.AllowDynamicResolution\r\n"
                + "\tPlayerSetting中要开启EnableFrameTimingStats\r\n"
                + "动态分辨率最大缩放")
            , DefaultValue(1.0f)]
        public float DynamicResolutionScaleMax { get; set; }
        [Category("Renderer")
            , Description("动态分辨率最小缩放")
            , DefaultValue(0.5f)]
        public float DynamicResolutionScaleMin { get; set; }
        [Category("Renderer")
            , Description("动态分辨率缩放步长")
            , DefaultValue(0.05f)]
        public float DynamicResolutionScaleStep { get; set; }
        [Category("Renderer")
            , Description("动态分辨率目标帧率")
            , DefaultValue(60.0f)]
        public float DynamicResolutionTargetFPS { get; set; }
        [Category("Renderer")
            , Description("动态分辨率目标帧率运行的震动")
            , DefaultValue(0.1f)]
        public float DynamicResolutionAllowShake { get; set; }
        [Category("Renderer")
            , Description("see CameraRenderer.Setting")
            , DefaultValue("{\"EnableDownsampleDepth\":false,\"DownsampleDepthCoefficient\":0.5}")]
        public string MainCameraRendererSetting { get; set; }
        #endregion

        #region Mail
        [Category("Mail")
            , Description("默认的Smtp host:userName:password")
            , DefaultValue("smtp.mxhichina.com:debugger@huangwm.com:Debug199396")]
        public string DefaultSmtpClient { get; set; }
        [Category("Mail")
         , Description("默认的发件人")
         , DefaultValue("debugger@huangwm.com")]
        public string DefaultFromAddress { get; set; }
        [Category("Mail")
         , Description("{ToAddress} 多个收件人以':'分隔\r\n"
            + "Debug组的收件人列表")
         , DefaultValue("hwm@huangwm.com")]
        public string DebugToAddress { get; set; }
        #endregion
    }
}