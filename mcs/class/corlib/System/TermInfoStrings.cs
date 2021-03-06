//
// System.TermInfoStrings
//
// Authors:
//	Gonzalo Paniagua Javier (gonzalo@ximian.com)
//
// (C) 2005 Novell, Inc (http://www.novell.com)
//

//
// Permission is hereby granted, free of charge, to any person obtaining
// a copy of this software and associated documentation files (the
// "Software"), to deal in the Software without restriction, including
// without limitation the rights to use, copy, modify, merge, publish,
// distribute, sublicense, and/or sell copies of the Software, and to
// permit persons to whom the Software is furnished to do so, subject to
// the following conditions:
// 
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
// LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
// OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
// WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
//
#if !NET_2_1

// These values are taken from 'man 5 terminfo' and /usr/include/term.h.
// They are the indexes for the string capabilities in a terminfo file.
namespace System {
	enum TermInfoStrings {
		BackTab,		// 0
		Bell,
		CarriageReturn,
		ChangeScrollRegion,
		ClearAllTabs,
		ClearScreen,
		ClrEol,
		ClrEos,
		ColumnAddress,
		CommandCharacter,
		CursorAddress,
		CursorDown,
		CursorHome,
		CursorInvisible,
		CursorLeft,
		CursorMemAddress,
		CursorNormal,
		CursorRight,
		CursorToLl,
		CursorUp,
		CursorVisible,
		DeleteCharacter,
		DeleteLine,
		DisStatusLine,
		DownHalfLine,
		EnterAltCharsetMode,
		EnterBlinkMode,
		EnterBoldMode,
		EnterCaMode,
		EnterDeleteMode,
		EnterDimMode,
		EnterInsertMode,
		EnterSecureMode,
		EnterProtectedMode,
		EnterReverseMode,
		EnterStandoutMode,
		EnterUnderlineMode,
		EraseChars,
		ExitAltCharsetMode,
		ExitAttributeMode,
		ExitCaMode,
		ExitDeleteMode,
		ExitInsertMode,
		ExitStandoutMode,
		ExitUnderlineMode,
		FlashScreen,
		FormFeed,
		FromStatusLine,
		Init1string,
		Init2string,
		Init3string,
		InitFile,
		InsertCharacter,
		InsertLine,
		InsertPadding,
		KeyBackspace,
		KeyCatab,
		KeyClear,
		KeyCtab,
		KeyDc,
		KeyDl,
		KeyDown,
		KeyEic,
		KeyEol,
		KeyEos,
		KeyF0,
		KeyF1,
		KeyF10,
		KeyF2,
		KeyF3,
		KeyF4,
		KeyF5,
		KeyF6,
		KeyF7,
		KeyF8,
		KeyF9,
		KeyHome,
		KeyIc,
		KeyIl,
		KeyLeft,
		KeyLl,
		KeyNpage,
		KeyPpage,
		KeyRight,
		KeySf,
		KeySr,
		KeyStab,
		KeyUp,
		KeypadLocal,
		KeypadXmit,
		LabF0,
		LabF1,
		LabF10,
		LabF2,
		LabF3,
		LabF4,
		LabF5,
		LabF6,
		LabF7,
		LabF8,
		LabF9,
		MetaOff,
		MetaOn,
		Newline,
		PadChar,
		ParmDch,
		ParmDeleteLine,
		ParmDownCursor,
		ParmIch,
		ParmIndex,
		ParmInsertLine,
		ParmLeftCursor,
		ParmRightCursor,
		ParmRindex,
		ParmUpCursor,
		PkeyKey,
		PkeyLocal,
		PkeyXmit,
		PrintScreen,
		PrtrOff,
		PrtrOn,
		RepeatChar,
		Reset1string,
		Reset2string,
		Reset3string,
		ResetFile,
		RestoreCursor,
		RowAddress,
		SaveCursor,
		ScrollForward,
		ScrollReverse,
		SetAttributes,
		SetTab,
		SetWindow,
		Tab,
		ToStatusLine,
		UnderlineChar,
		UpHalfLine,
		InitProg,
		KeyA1,
		KeyA3,
		KeyB2,
		KeyC1,
		KeyC3,
		PrtrNon,
		CharPadding,
		AcsChars,
		PlabNorm,
		KeyBtab,
		EnterXonMode,
		ExitXonMode,
		EnterAmMode,
		ExitAmMode,
		XonCharacter,
		XoffCharacter,
		EnaAcs,
		LabelOn,
		LabelOff,
		KeyBeg,
		KeyCancel,
		KeyClose,
		KeyCommand,
		KeyCopy,
		KeyCreate,
		KeyEnd,
		KeyEnter,
		KeyExit,
		KeyFind,
		KeyHelp,
		KeyMark,
		KeyMessage,
		KeyMove,
		KeyNext,
		KeyOpen,
		KeyOptions,
		KeyPrevious,
		KeyPrint,
		KeyRedo,
		KeyReference,
		KeyRefresh,
		KeyReplace,
		KeyRestart,
		KeyResume,
		KeySave,
		KeySuspend,
		KeyUndo,
		KeySbeg,
		KeyScancel,
		KeyScommand,
		KeyScopy,
		KeyScreate,
		KeySdc,
		KeySdl,
		KeySelect,
		KeySend,
		KeySeol,
		KeySexit,
		KeySfind,
		KeyShelp,
		KeyShome,
		KeySic,
		KeySleft,
		KeySmessage,
		KeySmove,
		KeySnext,
		KeySoptions,
		KeySprevious,
		KeySprint,
		KeySredo,
		KeySreplace,
		KeySright,
		KeySrsume,
		KeySsave,
		KeySsuspend,
		KeySundo,
		ReqForInput,
		KeyF11,
		KeyF12,
		KeyF13,
		KeyF14,
		KeyF15,
		KeyF16,
		KeyF17,
		KeyF18,
		KeyF19,
		KeyF20,
		KeyF21,
		KeyF22,
		KeyF23,
		KeyF24,
		KeyF25,
		KeyF26,
		KeyF27,
		KeyF28,
		KeyF29,
		KeyF30,
		KeyF31,
		KeyF32,
		KeyF33,
		KeyF34,
		KeyF35,
		KeyF36,
		KeyF37,
		KeyF38,
		KeyF39,
		KeyF40,
		KeyF41,
		KeyF42,
		KeyF43,
		KeyF44,
		KeyF45,
		KeyF46,
		KeyF47,
		KeyF48,
		KeyF49,
		KeyF50,
		KeyF51,
		KeyF52,
		KeyF53,
		KeyF54,
		KeyF55,
		KeyF56,
		KeyF57,
		KeyF58,
		KeyF59,
		KeyF60,
		KeyF61,
		KeyF62,
		KeyF63,
		ClrBol,
		ClearMargins,
		SetLeftMargin,
		SetRightMargin,
		LabelFormat,
		SetClock,
		DisplayClock,
		RemoveClock,
		CreateWindow,
		GotoWindow,
		Hangup,
		DialPhone,
		QuickDial,
		Tone,
		Pulse,
		FlashHook,
		FixedPause,
		WaitTone,
		User0,
		User1,
		User2,
		User3,
		User4,
		User5,
		User6,
		User7,
		User8,
		User9,
		OrigPair,
		OrigColors,
		InitializeColor,
		InitializePair,
		SetColorPair,
		SetForeground,
		SetBackground,
		ChangeCharPitch,
		ChangeLinePitch,
		ChangeResHorz,
		ChangeResVert,
		DefineChar,
		EnterDoublewideMode,
		EnterDraftQuality,
		EnterItalicsMode,
		EnterLeftwardMode,
		EnterMicroMode,
		EnterNearLetterQuality,
		EnterNormalQuality,
		EnterShadowMode,
		EnterSubscriptMode,
		EnterSuperscriptMode,
		EnterUpwardMode,
		ExitDoublewideMode,
		ExitItalicsMode,
		ExitLeftwardMode,
		ExitMicroMode,
		ExitShadowMode,
		ExitSubscriptMode,
		ExitSuperscriptMode,
		ExitUpwardMode,
		MicroColumnAddress,
		MicroDown,
		MicroLeft,
		MicroRight,
		MicroRowAddress,
		MicroUp,
		OrderOfPins,
		ParmDownMicro,
		ParmLeftMicro,
		ParmRightMicro,
		ParmUpMicro,
		SelectCharSet,
		SetBottomMargin,
		SetBottomMarginParm,
		SetLeftMarginParm,
		SetRightMarginParm,
		SetTopMargin,
		SetTopMarginParm,
		StartBitImage,
		StartCharSetDef,
		StopBitImage,
		StopCharSetDef,
		SubscriptCharacters,
		SuperscriptCharacters,
		TheseCauseCr,
		ZeroMotion,
		CharSetNames,
		KeyMouse,
		MouseInfo,
		ReqMousePos,
		GetMouse,
		SetAForeground,
		SetABackground,
		PkeyPlab,
		DeviceType,
		CodeSetInit,
		Set0DesSeq,
		Set1DesSeq,
		Set2DesSeq,
		Set3DesSeq,
		SetLrMargin,
		SetTbMargin,
		BitImageRepeat,
		BitImageNewline,
		BitImageCarriageReturn,
		ColorNames,
		DefineBitImageRegion,
		EndBitImageRegion,
		SetColorBand,
		SetPageLength,
		DisplayPcChar,
		EnterPcCharsetMode,
		ExitPcCharsetMode,
		EnterScancodeMode,
		ExitScancodeMode,
		PcTermOptions,
		ScancodeEscape,
		AltScancodeEsc,
		EnterHorizontalHlMode,
		EnterLeftHlMode,
		EnterLowHlMode,
		EnterRightHlMode,
		EnterTopHlMode,
		EnterVerticalHlMode,
		SetAAttributes,
		SetPglenInch,		// 393
		Last
	}
}
#endif

