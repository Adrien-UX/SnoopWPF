// (c) Copyright Cory Plotts.
// This source is subject to the Microsoft Public License (Ms-PL).
// Please see http://go.microsoft.com/fwlink/?LinkID=131993 for details.
// All other rights reserved.

namespace Snoop
{
	using System.Windows;
	using System.Windows.Data;
	using System;

	public class Expression: DependencyObject {

		public static readonly DependencyProperty ValueProperty = DependencyProperty.Register("Value", typeof(object), typeof(Expression), new PropertyMetadata(new PropertyChangedCallback(Expression.HandleValueChanged)));

		public Expression(object target, string path) {
			Binding binding = new Binding(path);
			binding.Source = target;

			try {
				BindingOperations.SetBinding(this, Expression.ValueProperty, binding);
			}
			catch (Exception) { }

			//this.Update();

			//this.isRunning = true;
		}

		public object Value {
			get { return this.GetValue(Expression.ValueProperty); }
			set { this.SetValue(Expression.ValueProperty, value); }
		}

		public string StringValue {
			get {
				object value = this.Value;
				if (value != null)
					return value.ToString();
				return string.Empty;
			}
		}

		protected virtual void OnValueChanged() {
			//this.Update();
		}

		private static void HandleValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e) {
			((Expression)d).OnValueChanged();
		}
	}
}