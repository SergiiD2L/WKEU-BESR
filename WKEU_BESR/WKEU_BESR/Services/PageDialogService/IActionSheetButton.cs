using System.Windows.Input;

namespace WKEU_BESR.Services.PageDialogService
{
    internal interface IActionSheetButton
    {
        /// <summary>
        /// The button will be used as destroy
        /// </summary>
        bool IsDestroy { get; }

        /// <summary>
        /// The button will be used as cancel
        /// </summary>
        bool IsCancel { get; }

        /// <summary>
        /// Text to display in the action sheet
        /// </summary>
        string Text { get; }

        /// <summary>
        /// Command to execute when button is pressed
        /// </summary>
        ICommand Command { get; }
    }
}