using UnityEngine;

namespace Command
{
    /// <summary>
    /// コマンド生成時に利用する構造体
    /// </summary>
    [System.Serializable]
    public class CommandStruct
    {
        [SerializeField, Tooltip("このコマンドがどの種類であるか")]
        public MainCommandType CommandType;
        [SerializeField, Tooltip("コマンドを移動可能であるか")]
        public bool LockCommand;
        [SerializeField, Tooltip("コマンドで使用する数値")]
        public int Value;
        [SerializeField, Tooltip("コマンド内の数値を移動可能であるか")]
        public bool LockNumber;
        [SerializeField, Tooltip("コマンドで使用する軸")]
        public CoordinateAxis Axis;
        [SerializeField, Tooltip("コマンド内の軸を移動可能であるか")]
        public bool LockCoordinateAxis;

        /// <summary>
        /// コンストラクタ(コンストラクタによる引数でのみ変数を変更できます)
        /// </summary>
        /// <param name="commandType">メインコマンドタイプ</param>
        /// <param name="lockCommand">コマンドが変更可能かどうか</param>
        /// <param name="lockNumber">数値が変更可能かどうか</param>
        /// <param name="lockCoordinateAxis">軸を変更可能かどうか</param>
        /// <param name="num">用いる数値</param>
        /// <param name="axis">用いる軸</param>
        public CommandStruct(MainCommandType commandType,
            bool lockCommand, bool lockNumber, bool lockCoordinateAxis,
            int num, CoordinateAxis axis, int capacity)
        {
            CommandType = commandType;
            LockCommand = lockCommand;
            LockNumber = lockNumber;
            LockCoordinateAxis = lockCoordinateAxis;
            Value = num;
            Axis = axis;
        }

        public CommandStruct() { }
    }

}