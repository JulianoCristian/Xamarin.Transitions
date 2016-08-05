﻿using System;
using CoreGraphics;
using OliveTree.Animations.iOS.Interpolators;
using UIKit;

namespace OliveTree.Transitions.iOS
{
    [TransitionHandler(typeof(Transitions.LayoutTransition))]
    public class LayoutTransition : TransitionBase
    {
        private CGRect _start;
        private CGPoint _startPosition;

        protected override void BeganAnimation(UIView target)
        {
            Console.WriteLine($"{target.GetHashCode()} - {target.Layer.Bounds}");
            _start = target.Layer.Bounds;
            _startPosition = target.Layer.Position;
        }

        protected override void EndingAnimation(UIView target)
        {
            target.LayoutIfNeeded();

            AnimateLayer(new RectInterpolator
            {
                From = _start,
                To = target.Layer.Bounds
            }, "bounds");

            AnimateLayer(new PointInterpolator
            {
                From = _startPosition,
                To = target.Layer.Position
            }, "position");
        }
    }
}

