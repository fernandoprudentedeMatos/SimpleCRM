import * as React from 'react';
import {Modal} from './common/Modal';
import MessageHandler from '../services/MessageHandler';

const callbackMessage = (message: string) => console.log(message);

interface IMessagesState {
    message: string;
    show: boolean
}

export class Messages extends React.Component<{}, IMessagesState> { 
    constructor() {
        super();

        this.state = {
            message: '',
            show: false
        };

        MessageHandler.addCallback((message: string) => {
            this.setNewMessage(message);
        })
    }

    setNewMessage(message: string) {
        this.setState({ message, show: true });
    }

    public render() {
        return (<Modal
            message={this.state.message}
            buttons={{
                ok: { label: 'OK', callback: () => { } }
            }}
            title={'Atenção!'}
            show={this.state.show} />);
    }
}