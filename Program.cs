using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Runtime.InteropServices;
using Newtonsoft.Json.Linq;

namespace robotclient {
    class ServerInfo {

        //机械臂IP地址
        const string robotIP = "192.168.65.138";
        //机械臂端口号
        const int serverPort = 8899;
        //机械臂web服务器地址
        public const string SERVER_URL = "http://localhost:8080/";

    }
    class Util {
        public const int RSERR_SUCC = 0;
        //关节个数
        public const int ARM_DOF = 6;
        //M_PI
        public const double M_PI = 3.14159265358979323846;

        //接口板用户DI地址
        public const int ROBOT_IO_F1 = 30;
        public const int ROBOT_IO_F2 = 31;
        public const int ROBOT_IO_F3 = 32;
        public const int ROBOT_IO_F4 = 33;
        public const int ROBOT_IO_F5 = 34;
        public const int ROBOT_IO_F6 = 35;
        public const int ROBOT_IO_U_DI_00 = 36;
        public const int ROBOT_IO_U_DI_01 = 37;
        public const int ROBOT_IO_U_DI_02 = 38;
        public const int ROBOT_IO_U_DI_03 = 39;
        public const int ROBOT_IO_U_DI_04 = 40;
        public const int ROBOT_IO_U_DI_05 = 41;
        public const int ROBOT_IO_U_DI_06 = 42;
        public const int ROBOT_IO_U_DI_07 = 43;
        public const int ROBOT_IO_U_DI_10 = 44;
        public const int ROBOT_IO_U_DI_11 = 45;
        public const int ROBOT_IO_U_DI_12 = 46;
        public const int ROBOT_IO_U_DI_13 = 47;
        public const int ROBOT_IO_U_DI_14 = 48;
        public const int ROBOT_IO_U_DI_15 = 49;
        public const int ROBOT_IO_U_DI_16 = 50;
        public const int ROBOT_IO_U_DI_17 = 51;

        //接口板用户DO地址
        public const int ROBOT_IO_U_DO_00 = 32;
        public const int ROBOT_IO_U_DO_01 = 33;
        public const int ROBOT_IO_U_DO_02 = 34;
        public const int ROBOT_IO_U_DO_03 = 35;
        public const int ROBOT_IO_U_DO_04 = 36;
        public const int ROBOT_IO_U_DO_05 = 37;
        public const int ROBOT_IO_U_DO_06 = 38;
        public const int ROBOT_IO_U_DO_07 = 39;
        public const int ROBOT_IO_U_DO_10 = 40;
        public const int ROBOT_IO_U_DO_11 = 41;
        public const int ROBOT_IO_U_DO_12 = 42;
        public const int ROBOT_IO_U_DO_13 = 43;
        public const int ROBOT_IO_U_DO_14 = 44;
        public const int ROBOT_IO_U_DO_15 = 45;
        public const int ROBOT_IO_U_DO_16 = 46;
        public const int ROBOT_IO_U_DO_17 = 47;

        //接口板用户AI地址
        const int ROBOT_IO_VI0 = 0;
        const int ROBOT_IO_VI1 = 1;
        const int ROBOT_IO_VI2 = 2;
        const int ROBOT_IO_VI3 = 3;

        //接口板用户AO地址
        public const int ROBOT_IO_VO0 = 0;
        public const int ROBOT_IO_VO1 = 1;
        public const int ROBOT_IO_CO0 = 2;
        public const int ROBOT_IO_CO1 = 3;

        //接口板IO类型
        //
        //接口板用户DI(数字量输入)　可读可写
        public const int Robot_User_DI = 4;
        //接口板用户DO(数字量输出)  可读可写
        public const int Robot_User_DO = 5;
        //接口板用户AI(模拟量输入)  可读可写
        public const int Robot_User_AI = 6;
        //接口板用户AO(模拟量输出)  可读可写
        public const int Robot_User_AO = 7;

        //工具端IO类型
        //
        //工具端DI
        public const int Robot_Tool_DI = 8;
        //工具端DO
        public const int Robot_Tool_DO = 9;
        //工具端AI
        public const int Robot_Tool_AI = 10;
        //工具端AO
        public const int Robot_Tool_AO = 11;
        //工具端DI
        public const int Robot_ToolIoType_DI = Robot_Tool_DI;
        //工具端DO
        public const int Robot_ToolIoType_DO = Robot_Tool_DO;

        //工具端IO名称
        public const string TOOL_IO_0 = ("T_DI/O_00");
        public const string TOOL_IO_1 = ("T_DI/O_01");
        public const string TOOL_IO_2 = ("T_DI/O_02");
        public const string TOOL_IO_3 = ("T_DI/O_03");

        //工具端数字IO类型
        //
        //输入
        public const int TOOL_IO_IN = 0;
        //输出
        public const int TOOL_IO_OUT = 0;

        //工具端电源类型
        //
        public const int OUT_0V = 0;
        public const int OUT_12V = 1;
        public const int OUT_24V = 2;

        //IO状态-无效
        public const double IO_STATUS_INVALID = 0.0;
        //IO状态-有效
        public const double IO_STATUS_VALID = 1.0;

        //坐标系枚举
        public const int BaseCoordinate = 0;
        public const int EndCoordinate = 1;
        public const int WorldCoordinate = 2;

        //坐标系标定方法
        public static string[] CoordMethodName = { "xOy", "yOz", "zOx", "xOxy", "xOxz", "yOyz", "yOyx", "zOzx", "zOzy" };

        //运动轨迹类型
        //
        //圆
        public const int ARC_CIR = 2;
        //圆弧
        public const int CARTESIAN_MOVEP = 3;

        //机械臂状态
        public const int RobotStopped = 0;
        public const int RobotRunning = 1;
        public const int RobotPaused = 2;
        public const int RobotResumed = 3;

        //机械臂工作模式
        public const int RobotModeSimulator = 0; //机械臂仿真模式
        public const int RobotModeReal = 1; //机械臂真实模式

        public static int GetCoordMothodByName (string methodName) {
            int method = -1;

            for (int i = 0; i < CoordMethodName.Length; i++) {
                if (methodName == CoordMethodName[i]) {
                    method = i;
                    break;
                }
            }
            return method;
        }

    }

    class MetaData {
        public enum CoordMethodIndex {
            xOy = 0, // 原点、x轴正半轴、y轴正半轴
            yOz, // 原点、y轴正半轴、z轴正半轴
            zOx, // 原点、z轴正半轴、x轴正半轴
            xOxy, // 原点、x轴正半轴、x、y轴平面的第一象限上任意一点
            xOxz, // 原点、x轴正半轴、x、z轴平面的第一象限上任意一点
            yOyz, // 原点、y轴正半轴、y、z轴平面的第一象限上任意一点
            yOyx, // 原点、y轴正半轴、y、x轴平面的第一象限上任意一点
            zOzx, // 原点、z轴正半轴、z、x轴平面的第一象限上任意一点
            zOzy // 原点、z轴正半轴、z、y轴平面的第一象限上任意一点
        }

        //路点位置信息的表示方法
        [StructLayout (LayoutKind.Sequential)]
        public struct Pos {
            public double x;
            public double y;
            public double z;
        }

        //路点位置信息的表示方法
        [StructLayout (LayoutKind.Sequential)]
        public struct cartesianPos_U {
            // 指定数组尺寸
            [MarshalAs (UnmanagedType.ByValArray, SizeConst = 3)]
            public double[] positionVector;
        };

        //姿态的四元素表示方法
        [StructLayout (LayoutKind.Sequential)]
        public struct Ori {
            public double w;
            public double x;
            public double y;
            public double z;
        };

        //姿态的欧拉角表示方法
        [StructLayout (LayoutKind.Sequential)]
        public struct Rpy {
            public double rx;
            public double ry;
            public double rz;
        };

        //描述机械臂的路点信息
        [StructLayout (LayoutKind.Sequential)]
        public struct wayPoint_S {
            //机械臂的位置信息　X,Y,Z
            public Pos cartPos;
            //机械臂姿态信息
            public Ori orientation;
            //机械臂关节角信息
            [MarshalAs (UnmanagedType.ByValArray, SizeConst = Util.ARM_DOF)]
            public double[] jointpos;
        };

        //机械臂关节速度加速度信息
        [StructLayout (LayoutKind.Sequential)]
        public struct JointVelcAccParam {
            [MarshalAs (UnmanagedType.ByValArray, SizeConst = Util.ARM_DOF)]
            public double[] jointPara;
        };

        //机械臂关节角度
        [StructLayout (LayoutKind.Sequential)]
        public struct JointRadian {
            [MarshalAs (UnmanagedType.ByValArray, SizeConst = Util.ARM_DOF)]
            public double[] jointRadian;
        };

        //机械臂工具端参数
        [StructLayout (LayoutKind.Sequential)]
        public struct ToolInEndDesc {
            //工具相对于末端坐标系的位置
            public Pos cartPos;
            //工具相对于末端坐标系的姿态
            public Ori orientation;
        };

        //坐标系结构体
        [StructLayout (LayoutKind.Sequential)]
        public struct CoordCalibrate {
            //坐标系类型：当coordType==BaseCoordinate或者coordType==EndCoordinate是，下面3个参数不做处理
            public int coordType;
            //坐标系标定方法
            public int methods;
            //用于标定坐标系的３个点（关节角），对应于机械臂法兰盘中心点基于基座标系
            [MarshalAs (UnmanagedType.ByValArray, SizeConst = 3)]
            public JointRadian[] jointPara;
            //标定的时候使用的工具描述
            public ToolInEndDesc toolDesc;
        };

        //转轴定义
        [StructLayout (LayoutKind.Sequential)]
        public struct MoveRotateAxis {
            [MarshalAs (UnmanagedType.ByValArray, SizeConst = 3)]
            public double[] rotateAxis;
        };

        //描述运动属性中的偏移属性
        [StructLayout (LayoutKind.Sequential)]
        public struct MoveRelative {
            //是否使能偏移
            public byte enable;
            //偏移量 x,y,z
            [MarshalAs (UnmanagedType.ByValArray, SizeConst = 3)]
            public float[] pos;
            //public Pos pos;
            //相对姿态偏移量
            public Ori orientation;
        };

        //该结构体描述工具惯量
        [StructLayout (LayoutKind.Sequential)]
        public struct ToolInertia {
            public double xx;
            public double xy;
            public double xz;
            public double yy;
            public double yz;
            public double zz;
        };

        //动力学参数
        [StructLayout (LayoutKind.Sequential)]
        public struct ToolDynamicsParam {
            public double positionX; //工具重心的X坐标
            public double positionY; //工具重心的Y坐标
            public double positionZ; //工具重心的Z坐标
            public double payload; //工具重量
            public ToolInertia toolInertia; //工具惯量
        };

        //机械臂事件
        [StructLayout (LayoutKind.Sequential)]
        public struct RobotEventInfo {
            public int eventType; //事件类型号
            public int eventCode; //事件代码
            public IntPtr eventContent; //事件内容(std::string)
        };
    }

    class RobotAdepter {
        public RobotAdepter () {
            if (rs_initialize () == Util.RSERR_SUCC) {
                if (rs_create_context (ref rshd) != Util.RSERR_SUCC) {
                    throw new Exception ("RobotAdepter init failed!");
                }
            }
        }

        ~RobotAdepter () {
            rs_uninitialize ();
        }
        //机械臂控制上下文句柄
        private UInt16 rshd = 0xffff;

#if _WIN32_PLATFORM
        const string Robot_Library = "libserviceinterface.dll";
#else
        const string Robot_Library = "libserviceinterface.so";
#endif

        //初始化机械臂控制库
        [DllImport (Robot_Library, EntryPoint = "rs_initialize", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        private static extern int rs_initialize ();

        //反初始化机械臂控制库
        [DllImport (Robot_Library, EntryPoint = "rs_uninitialize", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        private static extern int rs_uninitialize ();

        //创建机械臂控制上下文句柄
        [DllImport (Robot_Library, EntryPoint = "rs_create_context", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        public static extern int rs_create_context (ref UInt16 rshd);

        //注销机械臂控制上下文句柄
        [DllImport (Robot_Library, EntryPoint = "rs_destory_context", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        public static extern int rs_destory_context (UInt16 rshd);

        //链接机械臂服务器
        [DllImport (Robot_Library, EntryPoint = "rs_login", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        public static extern int rs_login (UInt16 rshd, [MarshalAs (UnmanagedType.LPStr)] string addr, int port);

        //断开机械臂服务器链接
        [DllImport (Robot_Library, EntryPoint = "rs_logout", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        public static extern int rs_logout (UInt16 rshd);

        //初始化全局的运动属性
        [DllImport (Robot_Library, EntryPoint = "rs_init_global_move_profile", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        public static extern int rs_init_global_move_profile (UInt16 rshd);

        //设置六个关节轴动的最大速度（最大为180度/秒），注意如果没有特殊需求，6个关节尽量配置成一样！
        [DllImport (Robot_Library, EntryPoint = "rs_set_global_joint_maxvelc", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        public static extern int rs_set_global_joint_maxvelc (UInt16 rshd, double[] max_velc);

        //获取六个关节轴动的最大速度
        [DllImport (Robot_Library, EntryPoint = "rs_get_global_joint_maxvelc", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        public static extern int rs_get_global_joint_maxvelc (UInt16 rshd, ref MetaData.JointVelcAccParam max_velc);

        //设置六个关节轴动的最大加速度 （十倍的最大速度），注意如果没有特殊需求，6个关节尽量配置成一样！
        [DllImport (Robot_Library, EntryPoint = "rs_set_global_joint_maxacc", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        public static extern int rs_set_global_joint_maxacc (UInt16 rshd, double[] max_acc);

        //获取六个关节轴动的最大加速度
        [DllImport (Robot_Library, EntryPoint = "rs_get_global_joint_maxacc", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        public static extern int rs_get_global_joint_maxacc (UInt16 rshd, ref MetaData.JointVelcAccParam max_acc);

        //设置机械臂末端最大线加速度
        [DllImport (Robot_Library, EntryPoint = "rs_set_global_end_max_line_acc", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        public static extern int rs_set_global_end_max_line_acc (UInt16 rshd, double max_acc);

        //设置机械臂末端最大线速度
        [DllImport (Robot_Library, EntryPoint = "rs_set_global_end_max_line_velc", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        public static extern int rs_set_global_end_max_line_velc (UInt16 rshd, double max_velc);

        //获取机械臂末端最大线加速度
        [DllImport (Robot_Library, EntryPoint = "rs_get_global_end_max_line_acc", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        public static extern int rs_get_global_end_max_line_acc (UInt16 rshd, ref double max_acc);

        //获取机械臂末端最大线速度
        [DllImport (Robot_Library, EntryPoint = "rs_get_global_end_max_line_velc", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        public static extern int rs_get_global_end_max_line_velc (UInt16 rshd, ref double max_velc);

        //设置机械臂末端最大角加速度
        [DllImport (Robot_Library, EntryPoint = "rs_set_global_end_max_angle_acc", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        public static extern int rs_set_global_end_max_angle_acc (UInt16 rshd, double max_acc);

        //设置机械臂末端最大角速度
        [DllImport (Robot_Library, EntryPoint = "rs_set_global_end_max_angle_velc", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        public static extern int rs_set_global_end_max_angle_velc (UInt16 rshd, double max_velc);

        //获取机械臂末端最大角加速度
        [DllImport (Robot_Library, EntryPoint = "rs_get_global_end_max_angle_acc", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        public static extern int rs_get_global_end_max_angle_acc (UInt16 rshd, ref double max_acc);

        //获取机械臂末端最大角加速度
        [DllImport (Robot_Library, EntryPoint = "rs_get_global_end_max_angle_velc", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        public static extern int rs_get_global_end_max_angle_velc (UInt16 rshd, ref double max_velc);

        //设置用户坐标系
        [DllImport (Robot_Library, EntryPoint = "rs_set_user_coord", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        public static extern int rs_set_user_coord (UInt16 rshd, ref MetaData.CoordCalibrate user_coord);

        //设置基座坐标系
        [DllImport (Robot_Library, EntryPoint = "rs_set_base_coord", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        public static extern int rs_set_base_coord (UInt16 rshd);

        //机械臂轴动
        [DllImport (Robot_Library, EntryPoint = "rs_move_joint", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        public static extern int rs_move_joint (UInt16 rshd, double[] joint_radia, bool isblock);

        //机械臂直线运动
        [DllImport (Robot_Library, EntryPoint = "rs_move_line", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        public static extern int rs_move_line (UInt16 rshd, double[] joint_radia, bool isblock);

        //保持当前位置变换姿态做旋转运动
        [DllImport (Robot_Library, EntryPoint = "rs_move_rotate", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        public static extern int rs_move_rotate (UInt16 rshd, ref MetaData.CoordCalibrate user_coord, ref MetaData.MoveRotateAxis rotate_axis, double rotate_angle, bool isblock);

        //清除所有已经设置的全局路点
        [DllImport (Robot_Library, EntryPoint = "rs_remove_all_waypoint", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        public static extern int rs_remove_all_waypoint (UInt16 rshd);

        //添加全局路点用于轨迹运动
        [DllImport (Robot_Library, EntryPoint = "rs_add_waypoint", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        public static extern int rs_add_waypoint (UInt16 rshd, double[] joint_radia);

        //设置交融半径
        [DllImport (Robot_Library, EntryPoint = "rs_set_blend_radius", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        public static extern int rs_set_blend_radius (UInt16 rshd, double radius);

        //设置圆运动圈数
        [DllImport (Robot_Library, EntryPoint = "rs_set_circular_loop_times", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        public static extern int rs_set_circular_loop_times (UInt16 rshd, int times);

        //检查用户坐标系参数设置是否合理
        [DllImport (Robot_Library, EntryPoint = "rs_check_user_coord", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        public static extern int rs_check_user_coord (UInt16 rshd, ref MetaData.CoordCalibrate user_coord);

        //设置基于基座标系运动偏移量
        [DllImport (Robot_Library, EntryPoint = "rs_set_relative_offset_on_base", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        public static extern int rs_set_relative_offset_on_base (UInt16 rshd, ref MetaData.MoveRelative relative);

        //设置基于用户标系运动偏移量
        [DllImport (Robot_Library, EntryPoint = "rs_set_relative_offset_on_user", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        public static extern int rs_set_relative_offset_on_user (UInt16 rshd, ref MetaData.MoveRelative relative, ref MetaData.CoordCalibrate user_coord);

        //取消提前到位设置
        [DllImport (Robot_Library, EntryPoint = "rs_set_no_arrival_ahead", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        public static extern int rs_set_no_arrival_ahead (UInt16 rshd);

        //设置距离模式下的提前到位距离
        [DllImport (Robot_Library, EntryPoint = "rs_set_arrival_ahead_distance", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        public static extern int rs_set_arrival_ahead_distance (UInt16 rshd, double distance);

        //设置时间模式下的提前到位时间
        [DllImport (Robot_Library, EntryPoint = "rs_set_arrival_ahead_time", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        public static extern int rs_set_arrival_ahead_time (UInt16 rshd, double sec);

        //轨迹运动
        [DllImport (Robot_Library, EntryPoint = "rs_move_track", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        public static extern int rs_move_track (UInt16 rshd, int sub_move_mode, bool isblock);

        //保持当前位姿通过直线运动的方式运动到目标位置
        [DllImport (Robot_Library, EntryPoint = "rs_move_line_to", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        public static extern int rs_move_line_to (UInt16 rshd, ref MetaData.Pos target, ref MetaData.ToolInEndDesc tool, bool isblock);

        //保持当前位姿通过关节运动的方式运动到目标位置
        [DllImport (Robot_Library, EntryPoint = "rs_move_joint_to", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        public static extern int rs_move_joint_to (UInt16 rshd, ref MetaData.Pos target, ref MetaData.ToolInEndDesc tool, bool isblock);

        //获取机械臂当前位置信息
        [DllImport (Robot_Library, EntryPoint = "rs_get_current_waypoint", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        public static extern int rs_get_current_waypoint (UInt16 rshd, ref MetaData.wayPoint_S waypoint);

        //正解
        [DllImport (Robot_Library, EntryPoint = "rs_forward_kin", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        public static extern int rs_forward_kin (UInt16 rshd, double[] joint_radia, ref MetaData.wayPoint_S waypoint);

        //逆解
        [DllImport (Robot_Library, EntryPoint = "rs_inverse_kin", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        public static extern int rs_inverse_kin (UInt16 rshd, double[] joint_radia, ref MetaData.Pos pos, ref MetaData.Ori ori, ref MetaData.wayPoint_S waypoint);

        //四元素转欧拉角
        [DllImport (Robot_Library, EntryPoint = "rs_rpy_to_quaternion", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        public static extern int rs_rpy_to_quaternion (UInt16 rshd, ref MetaData.Rpy rpy, ref MetaData.Ori ori);

        //欧拉角转四元素
        [DllImport (Robot_Library, EntryPoint = "rs_quaternion_to_rpy", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        public static extern int rs_quaternion_to_rpy (UInt16 rshd, ref MetaData.Ori ori, ref MetaData.Rpy rpy);

        //基座坐标系转用户坐标系
        [DllImport (Robot_Library, EntryPoint = "rs_base_to_user", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        public static extern int rs_base_to_user (UInt16 rshd, ref MetaData.Pos pos_onbase, ref MetaData.Ori ori_onbase, ref MetaData.CoordCalibrate user_coord, ref MetaData.ToolInEndDesc tool_pos, ref MetaData.Pos pos_onuser, ref MetaData.Ori ori_onuser);

        //用户坐标系转基座坐标系
        [DllImport (Robot_Library, EntryPoint = "rs_user_to_base", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        public static extern int rs_user_to_base (UInt16 rshd, ref MetaData.Pos pos_onuser, ref MetaData.Ori ori_onuser, ref MetaData.CoordCalibrate user_coord, ref MetaData.ToolInEndDesc tool_pos, ref MetaData.Pos pos_onbase, ref MetaData.Ori ori_onbase);

        //基坐标系转基座标得到工具末端点的位置和姿态
        [DllImport (Robot_Library, EntryPoint = "rs_base_to_base_additional_tool", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        public static extern int rs_base_to_base_additional_tool (UInt16 rshd, ref MetaData.Pos flange_center_pos_onbase, ref MetaData.Ori flange_center_ori_onbase, ref MetaData.ToolInEndDesc tool_pos, ref MetaData.Pos tool_end_pos_onbase, ref MetaData.Ori tool_end_ori_onbase);

        //设置工具的运动学参数
        [DllImport (Robot_Library, EntryPoint = "rs_set_tool_end_param", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        public static extern int rs_set_tool_end_param (UInt16 rshd, ref MetaData.ToolInEndDesc tool);

        //设置无工具的动力学参数
        [DllImport (Robot_Library, EntryPoint = "rs_set_none_tool_dynamics_param", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        public static extern int rs_set_none_tool_dynamics_param (UInt16 rshd);

        //根据接口板IO类型和地址设置IO状态
        [DllImport (Robot_Library, EntryPoint = "rs_set_board_io_status_by_addr", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        public static extern int rs_set_board_io_status_by_addr (UInt16 rshd, int io_type, int addr, double val);

        //根据接口板IO类型和地址获取IO状态
        [DllImport (Robot_Library, EntryPoint = "rs_get_board_io_status_by_addr", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        public static extern int rs_get_board_io_status_by_addr (UInt16 rshd, int io_type, int addr, ref double val);

        //设置工具端IO状态
        [DllImport (Robot_Library, EntryPoint = "rs_set_tool_do_status", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern int rs_set_tool_do_status (UInt16 rshd, string name, int val);

        //获取工具端IO状态
        [DllImport (Robot_Library, EntryPoint = "rs_get_tool_io_status", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern int rs_get_tool_io_status (UInt16 rshd, string name, ref double val);

        //设置工具端电源电压类型
        [DllImport (Robot_Library, EntryPoint = "rs_set_tool_power_type", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        public static extern int rs_set_tool_power_type (UInt16 rshd, int type);

        //获取工具端电源电压类型
        [DllImport (Robot_Library, EntryPoint = "rs_get_tool_power_type", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        public static extern int rs_get_tool_power_type (UInt16 rshd, ref int type);

        //设置工具端数字量IO的类型
        [DllImport (Robot_Library, EntryPoint = "rs_set_tool_io_type", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        public static extern int rs_set_tool_io_type (UInt16 rshd, int addr, int type);

        //设置工具的动力学参数
        [DllImport (Robot_Library, EntryPoint = "rs_set_tool_dynamics_param", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        public static extern int rs_set_tool_dynamics_param (UInt16 rshd, ref MetaData.ToolDynamicsParam tool);

        //获取工具的动力学参数
        [DllImport (Robot_Library, EntryPoint = "rs_get_tool_dynamics_param", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        public static extern int rs_get_tool_dynamics_param (UInt16 rshd, ref MetaData.ToolDynamicsParam tool);

        //设置无工具运动学参数
        [DllImport (Robot_Library, EntryPoint = "rs_set_none_tool_kinematics_param", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        public static extern int rs_set_none_tool_kinematics_param (UInt16 rshd);

        //设置工具的运动学参数
        [DllImport (Robot_Library, EntryPoint = "rs_set_tool_kinematics_param", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        public static extern int rs_set_tool_kinematics_param (UInt16 rshd, ref MetaData.ToolInEndDesc tool);

        //获取工具的运动学参数
        [DllImport (Robot_Library, EntryPoint = "rs_get_tool_kinematics_param", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        public static extern int rs_get_tool_kinematics_param (UInt16 rshd, ref MetaData.ToolInEndDesc tool);

        //启动机械臂
        [DllImport (Robot_Library, EntryPoint = "rs_robot_startup", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        public static extern int rs_robot_startup (UInt16 rshd, ref MetaData.ToolDynamicsParam tool, byte colli_class, bool read_pos, bool static_colli_detect, int board_maxacc, ref int state);

        //关闭机械臂
        [DllImport (Robot_Library, EntryPoint = "rs_robot_shutdown", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        public static extern int rs_robot_shutdown (UInt16 rshd);

        //停止机械臂运动
        [DllImport (Robot_Library, EntryPoint = "rs_move_stop", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        public static extern int rs_move_stop (UInt16 rshd);

        //停止机械臂运动
        [DllImport (Robot_Library, EntryPoint = "rs_move_fast_stop", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        public static extern int rs_move_fast_stop (UInt16 rshd);

        //暂停机械臂运动
        [DllImport (Robot_Library, EntryPoint = "rs_move_pause", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        public static extern int rs_move_pause (UInt16 rshd);

        //暂停后回复机械臂运动
        [DllImport (Robot_Library, EntryPoint = "rs_move_continue", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        public static extern int rs_move_continue (UInt16 rshd);

        //机械臂碰撞后恢复
        [DllImport (Robot_Library, EntryPoint = "rs_collision_recover", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        public static extern int rs_collision_recover (UInt16 rshd);

        //获取机械臂当前状态
        [DllImport (Robot_Library, EntryPoint = "rs_get_robot_state", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        public static extern int rs_get_robot_state (UInt16 rshd, ref int state);

        //设置机械臂服务器工作模式
        [DllImport (Robot_Library, EntryPoint = "rs_set_work_mode", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        public static extern int rs_set_work_mode (UInt16 rshd, int state);

        //获取机械臂服务器当前工作模式
        [DllImport (Robot_Library, EntryPoint = "rs_get_work_mode", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        public static extern int rs_get_work_mode (UInt16 rshd, ref int state);

        //设置机械臂碰撞等级
        [DllImport (Robot_Library, EntryPoint = "rs_set_collision_class", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        public static extern int rs_set_collision_class (UInt16 rshd, int grade);

        //获取socket链接状态
        [DllImport (Robot_Library, EntryPoint = "rs_get_socket_status", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        public static extern int rs_get_socket_status (UInt16 rshd, ref byte connected);

        //设置是否允许实时路点信息推送
        [DllImport (Robot_Library, EntryPoint = "rs_enable_push_realtime_roadpoint", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        public static extern int rs_enable_push_realtime_roadpoint (UInt16 rshd, bool enable);

        //实时路点回调函数
        [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute (System.Runtime.InteropServices.CallingConvention.Cdecl)]
        public delegate void REALTIME_ROADPOINT_CALLBACK (ref MetaData.wayPoint_S waypoint, IntPtr arg);

        [DllImport (Robot_Library, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rs_setcallback_realtime_roadpoint (UInt16 rshd, [MarshalAs (UnmanagedType.FunctionPtr)] REALTIME_ROADPOINT_CALLBACK CurrentPositionCallback, IntPtr arg);

        //机械臂事件
        [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute (System.Runtime.InteropServices.CallingConvention.Cdecl)]
        public delegate void ROBOT_EVENT_CALLBACK (ref MetaData.RobotEventInfo rs_event, IntPtr arg);

        [DllImport (Robot_Library, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rs_setcallback_robot_event (UInt16 rshd, [MarshalAs (UnmanagedType.FunctionPtr)] ROBOT_EVENT_CALLBACK RobotEventCallback, IntPtr arg);

        //回调函数
        static void CurrentPositionCallback (ref MetaData.wayPoint_S waypoint, IntPtr arg) {
            PrintWaypoint (waypoint);
        }

        //打印路点信息
        static void PrintWaypoint (MetaData.wayPoint_S point) {
            Console.Out.WriteLine ("---------------------------------------------------------------------------------------");
            Console.Out.WriteLine ("pos.x={0} y={1} z={2}", point.cartPos.x, point.cartPos.y, point.cartPos.z);
            Console.Out.WriteLine ("ori.w={0} x={1} y={2} z={3}", point.orientation.w, point.orientation.x, point.orientation.y, point.orientation.z);
            Console.Out.WriteLine ("joint1={0} joint2={1} joint3={2}", point.jointpos[0] * 180 / Util.M_PI, point.jointpos[1] * 180 / Util.M_PI, point.jointpos[2] * 180 / Util.M_PI);
            Console.Out.WriteLine ("joint4={0} joint5={1} joint6={2}", point.jointpos[3] * 180 / Util.M_PI, point.jointpos[4] * 180 / Util.M_PI, point.jointpos[5] * 180 / Util.M_PI);
            Console.Out.WriteLine ("---------------------------------------------------------------------------------------");
        }

        static void RobotEventCallback (ref MetaData.RobotEventInfo rs_event, IntPtr arg) {
            Console.Out.WriteLine ("---------------------------------------------------------------------------------------");
            Console.Out.WriteLine ("robot event.type={0}", rs_event.eventType);
            Console.Out.WriteLine ("robot event.eventCode={0}", rs_event.eventCode);
            Console.Out.WriteLine ("robot event.eventContent={0}", Marshal.PtrToStringAnsi (rs_event.eventContent));
            Console.Out.WriteLine ("---------------------------------------------------------------------------------------");
        }

        static string HttpGet (string url) {
            string result = string.Empty;
            try {
                HttpWebRequest wbRequest = (HttpWebRequest) WebRequest.Create (url);
                wbRequest.Method = "GET";
                HttpWebResponse wbResponse = (HttpWebResponse) wbRequest.GetResponse ();
                using (Stream responseStream = wbResponse.GetResponseStream ()) {
                    using (StreamReader sReader = new StreamReader (responseStream)) {
                        result = sReader.ReadToEnd ();
                    }
                }
            } catch (Exception ex) {
                Console.WriteLine (ex.ToString ());
            }
            return result;
        }

        public void GetToolNameList (string strServerUrl, out List<string> list) {
            string strURL = strServerUrl + "api/gettools";
            string data = HttpGet (strURL);
            list = new List<string> ();
            if (data != string.Empty) {
                try {
                    JArray toolArray = Newtonsoft.Json.Linq.JArray.Parse (data) as JArray;
                    foreach (JArray item in toolArray) {
                        JObject toolJobject = Newtonsoft.Json.JsonConvert.DeserializeObject (item[0].ToString ()) as JObject;
                        list.Add (toolJobject["tool_name"].ToString ());
                    }

                } catch (Exception ex) {
                    Console.WriteLine (ex.ToString ());
                }

            } else {
                Console.WriteLine ("get tool error!");
            }
        }

        public void GetCoordNameList (string strServerUrl, out List<string> list) {
            string strURL = strServerUrl + "api/getcoords";
            string data = HttpGet (strURL);
            list = new List<string> ();
            if (data != string.Empty) {
                try {
                    JArray coordArray = Newtonsoft.Json.Linq.JArray.Parse (data) as JArray;
                    foreach (JArray item in coordArray) {
                        JObject coordJobject = Newtonsoft.Json.JsonConvert.DeserializeObject (item[0].ToString ()) as JObject;
                        list.Add (coordJobject["coord_name"].ToString ());
                    }

                } catch (Exception ex) {
                    Console.WriteLine (ex.ToString ());
                }

            } else {
                Console.WriteLine ("get coord error!");
            }
        }

        public bool GetTool (string strServerUrl, string strToolName, out MetaData.ToolInEndDesc robotTool) {
            bool bfound = false;
            MetaData.Rpy rpy = new MetaData.Rpy ();
            robotTool = new MetaData.ToolInEndDesc ();
            string strURL = strServerUrl + "api/gettools";
            string data = HttpGet (strURL);
            if (data != string.Empty) {
                try {
                    JArray toolArray = Newtonsoft.Json.Linq.JArray.Parse (data) as JArray;
                    foreach (JArray item in toolArray) {
                        JObject toolJobject = Newtonsoft.Json.JsonConvert.DeserializeObject (item[0].ToString ()) as JObject;
                        if (toolJobject["tool_name"].ToString () == strToolName) {
                            robotTool.cartPos.x = double.Parse (toolJobject["x"].ToString ());
                            robotTool.cartPos.y = double.Parse (toolJobject["y"].ToString ());
                            robotTool.cartPos.z = double.Parse (toolJobject["z"].ToString ());

                            rpy.rx = double.Parse (toolJobject["rx"].ToString ());
                            rpy.ry = double.Parse (toolJobject["ry"].ToString ());
                            rpy.rz = double.Parse (toolJobject["rz"].ToString ());

                            //欧拉角转四元数
                            rs_rpy_to_quaternion (rshd, ref rpy, ref robotTool.orientation);

                            Console.WriteLine ("tool.name=" + strToolName);
                            Console.WriteLine ("tool.pos.x=" + robotTool.cartPos.x.ToString ());
                            Console.WriteLine ("tool.pos.y=" + robotTool.cartPos.y.ToString ());
                            Console.WriteLine ("tool.pos.z=" + robotTool.cartPos.z.ToString ());
                            Console.WriteLine ("tool.ori.w=" + robotTool.orientation.w.ToString ());
                            Console.WriteLine ("tool.ori.x=" + robotTool.orientation.x.ToString ());
                            Console.WriteLine ("tool.ori.y=" + robotTool.orientation.y.ToString ());
                            Console.WriteLine ("tool.ori.z=" + robotTool.orientation.z.ToString ());

                            bfound = true;
                            break;
                        }

                    }

                } catch (Exception ex) {
                    Console.WriteLine (ex.ToString ());
                }
            } else {
                Console.WriteLine ("get tool error!");
            }

            return bfound;
        }

        public bool GetCoord (string strServerUrl, string strCoordName, ref MetaData.CoordCalibrate coord) {
            bool bfound = false;
            MetaData.Rpy rpy = new MetaData.Rpy ();
            string strURL = strServerUrl + "api/getcoords";
            string data = HttpGet (strURL);
            if (data != string.Empty) {
                if (data != string.Empty) {
                    try {
                        JArray coordArray = Newtonsoft.Json.Linq.JArray.Parse (data) as JArray;
                        foreach (JArray item in coordArray) {
                            JObject coordJobject = Newtonsoft.Json.JsonConvert.DeserializeObject (item[0].ToString ()) as JObject;
                            Console.WriteLine (coordJobject["coord_name"].ToString ());

                            if (coordJobject["coord_name"].ToString () == strCoordName) {
                                //method
                                coord.methods = Util.GetCoordMothodByName (coordJobject["method"].ToString ());

                                //coord type
                                coord.coordType = Util.WorldCoordinate;

                                //coord point1~3
                                string[] point1 = coordJobject["point1"].ToString ().Split (',');

                                coord.jointPara[0].jointRadian[0] = double.Parse (point1[7]);
                                coord.jointPara[0].jointRadian[1] = double.Parse (point1[8]);
                                coord.jointPara[0].jointRadian[2] = double.Parse (point1[9]);
                                coord.jointPara[0].jointRadian[3] = double.Parse (point1[10]);
                                coord.jointPara[0].jointRadian[4] = double.Parse (point1[11]);
                                coord.jointPara[0].jointRadian[5] = double.Parse (point1[12]);

                                string[] point2 = coordJobject["point2"].ToString ().Split (',');
                                coord.jointPara[1].jointRadian[0] = double.Parse (point2[7]);
                                coord.jointPara[1].jointRadian[1] = double.Parse (point2[8]);
                                coord.jointPara[1].jointRadian[2] = double.Parse (point2[9]);
                                coord.jointPara[1].jointRadian[3] = double.Parse (point2[10]);
                                coord.jointPara[1].jointRadian[4] = double.Parse (point2[11]);
                                coord.jointPara[1].jointRadian[5] = double.Parse (point2[12]);

                                string[] point3 = coordJobject["point3"].ToString ().Split (',');
                                coord.jointPara[2].jointRadian[0] = double.Parse (point3[7]);
                                coord.jointPara[2].jointRadian[1] = double.Parse (point3[8]);
                                coord.jointPara[2].jointRadian[2] = double.Parse (point3[9]);
                                coord.jointPara[2].jointRadian[3] = double.Parse (point3[10]);
                                coord.jointPara[2].jointRadian[4] = double.Parse (point3[11]);
                                coord.jointPara[2].jointRadian[5] = double.Parse (point3[12]);

                                //coordinate tool describle
                                coord.toolDesc.cartPos.x = double.Parse (coordJobject["x"].ToString ());
                                coord.toolDesc.cartPos.y = double.Parse (coordJobject["y"].ToString ());
                                coord.toolDesc.cartPos.z = double.Parse (coordJobject["z"].ToString ());

                                //欧拉角转四元数
                                rs_rpy_to_quaternion (rshd, ref rpy, ref coord.toolDesc.orientation);

                                Console.WriteLine ("coord.method=" + coord.methods.ToString ());
                                Console.WriteLine ("coord.point1=" + coordJobject["point1"].ToString ());
                                Console.WriteLine ("coord.point2=" + coordJobject["point2"].ToString ());
                                Console.WriteLine ("coord.point3=" + coordJobject["point3"].ToString ());
                                Console.WriteLine ("coord.tool.name=" + coordJobject["tool_name"].ToString ());
                                Console.WriteLine ("coord.tool.pos.x=" + coord.toolDesc.cartPos.x.ToString ());
                                Console.WriteLine ("coord.tool.pos.y=" + coord.toolDesc.cartPos.y.ToString ());
                                Console.WriteLine ("coord.tool.pos.z=" + coord.toolDesc.cartPos.z.ToString ());
                                Console.WriteLine ("coord.tool.ori.w=" + coord.toolDesc.orientation.w.ToString ());
                                Console.WriteLine ("coord.tool.ori.x=" + coord.toolDesc.orientation.x.ToString ());
                                Console.WriteLine ("coord.tool.ori.y=" + coord.toolDesc.orientation.y.ToString ());
                                Console.WriteLine ("coord.tool.ori.z=" + coord.toolDesc.orientation.z.ToString ());

                                bfound = true;
                                break;
                            }
                        }

                    } catch (Exception ex) {
                        Console.WriteLine (ex.ToString ());
                    }
                } else {
                    Console.WriteLine ("get coordinate error!");
                }
            }

            return bfound;
        }
    }

    class Program {
        static void Main (string[] args) {
            //机械臂控制上下文句柄
            UInt16 rshd = 0xffff;
            //创建机械臂控制对象
            RobotAdepter robot = new RobotAdepter ();

            //获取所有工具名称列表
            List<string> toolNamelist;
            MetaData.ToolInEndDesc robotTool;
            robot.GetToolNameList (ServerInfo.SERVER_URL, out toolNamelist);
            foreach (string name in toolNamelist) {
                robot.GetTool (ServerInfo.SERVER_URL, name, out robotTool);
            }

            //获取所有坐标系名称列表
            List<string> coordNameList;
            robot.GetCoordNameList (ServerInfo.SERVER_URL, out coordNameList);
            foreach (string name in coordNameList) {
                MetaData.CoordCalibrate coord = new MetaData.CoordCalibrate ();
                //分配内存
                IntPtr pt_coord = Marshal.AllocHGlobal (Marshal.SizeOf (typeof (MetaData.CoordCalibrate)));
                coord = (MetaData.CoordCalibrate) Marshal.PtrToStructure (pt_coord, typeof (MetaData.CoordCalibrate));
                //获取坐标系参数
                robot.GetCoord (ServerInfo.SERVER_URL, name, ref coord);
                //必须释放内存否则会造成内存泄露!!!
                Marshal.FreeHGlobal (pt_coord);
            }

            //机械臂运动控制示例
            if (RobotAdepter.rs_create_context (ref rshd) == Util.RSERR_SUCC) {
                Console.Out.WriteLine ("rshd={0}", rshd);
                //other test...                
            }
        }
    }
}