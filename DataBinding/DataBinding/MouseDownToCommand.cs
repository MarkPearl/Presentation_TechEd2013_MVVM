using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace DataBinding
{
    public static class MouseDownToCommand
    {
        private static Dictionary<TextBox, ICommand> _mappedCommands = new Dictionary<TextBox, ICommand>();

        public static ICommand GetMappedCommand(DependencyObject obj)
        {
            return (ICommand)obj.GetValue(MappedCommand);
        }

        public static void SetMappedCommand(DependencyObject obj, ICommand value)
        {
            obj.SetValue(MappedCommand, value);
        }

        public static readonly DependencyProperty MappedCommand =
            DependencyProperty.RegisterAttached("MappedCommand",
                                        typeof(ICommand),
                                        typeof(MouseDownToCommand),
                                        new UIPropertyMetadata(null, OnMappedCommandPropertyChanged));

        public static void OnMappedCommandPropertyChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            var control = sender as TextBox;

            if (control != null)
            {
                if (_mappedCommands.ContainsKey(control)) _mappedCommands.Remove(control);

                var command = (ICommand)e.NewValue;
                if (command != null)
                {
                    _mappedCommands.Add(control, command);
                    control.MouseDoubleClick += control_MouseDoubleClick;
                }
            }
        }

        static void control_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var control = (TextBox)sender;
            _mappedCommands[control].Execute((null));
        }
    }
}