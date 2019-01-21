
export type CallbackMessage = (message: string) => void;

function MessageHandler() {

    let _callback: CallbackMessage = () => { };

    return {
        addCallback: (callback: CallbackMessage) => {
            _callback = callback;
        },
        showMessage: (message: string) => {
            _callback(message);
        }
    }
  }
  
const constHandler = MessageHandler();

export default constHandler;