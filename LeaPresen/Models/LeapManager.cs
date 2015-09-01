﻿using Leap;
using LeaPresen.Models.Actions;
using System;
using System.Windows.Media;

namespace LeaPresen.Models
{
    /// <summary>
    /// LeapMotionの制御を総括する静的クラス
    /// </summary>
    public static class LeapManager
    {
        private static readonly Controller controller;

        /// <summary>
        /// 静的コンストラクタ
        /// </summary>
        static LeapManager()
        {
            controller = new Controller();
            controller.EnableGesture(Gesture.GestureType.TYPE_SWIPE);
        }

        /// <summary>
        /// LeapMotionのトラッキングを開始
        /// </summary>
        public static void Start()
        {
            CompositionTarget.Rendering += Update;
        }

        /// <summary>
        /// ポインタを表示するアクションを設定
        /// </summary>
        /// <param name="pointAction">ポインタを表示するアクション</param>
        public static void SetPointAction(Action<double, double> pointAction)
        {
            PointAction.SetAction(pointAction);
        }

        public static void SetSlideAction(Action<int> slideAction)
        {
            SlideAction.SetAction(slideAction);
        }

        /// <summary>
        /// トラッキング中にアップデートされる部分
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void Update(object sender, EventArgs e)
        {
            Frame frame = controller.Frame();
            PointAction.Draw(frame);
            SlideAction.Turn(frame);
        }
    }
}