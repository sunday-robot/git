#if !defined(__CALLBACK_H__)
#define __CALLBACK_H__
class Panel;

typedef void (*CallbackProc)(Panel *_panel, Event *_event,
	void *_private_data);

class Callback {
	CallbackProc callbackProc;
	void *privateData;
public:
/*
	Callback(void (*_callback_proc)(Panel *, Event *, void *),
		void *_private_data) {
		callbackProc = _callback_proc;
		privateData = _private_data;
	};
*/
	Callback(CallbackProc _callback_proc, void *_private_data) {
		callbackProc = _callback_proc;
		privateData = _private_data;
	};
	void call(Panel *_panel, Event *_event) {
		callbackProc(_panel, _event, privateData);
	};
};
#endif __CALLBACK_H__
