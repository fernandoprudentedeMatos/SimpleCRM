import * as React from 'react';

export type ModalButtonItem = {
    label: string
    callback(param?: any): void
}

export type ModalButtons = {
    ok: ModalButtonItem
    cancel?: ModalButtonItem
}

interface IModalAlertProps {
    show: boolean
    message: string
    title: string
    buttons: ModalButtons
    param?: any
}

interface IModalAlertState {
   opened: boolean
}


export class Modal extends React.Component<IModalAlertProps, IModalAlertState> {
    constructor(props: IModalAlertProps) {
        super(props);
        this.state = {
            opened: false
        }

        this.cancel = this.cancel.bind(this);
        this.ok = this.ok.bind(this);
    }

    componentWillReceiveProps(nextProps: IModalAlertProps) {
        if (nextProps.show && !this.state.opened)
            this.setState({opened: true});
    }

    cancel() {
        const { cancel } = this.props.buttons;
        cancel && cancel.callback(this.props.param);
        this.setState({ opened: false });
    }

    ok() {
        this.setState({ opened: false });
        const { ok } = this.props.buttons;
        ok.callback(this.props.param);        
    }

    render() {
        const { cancel, ok } = this.props.buttons;
        return (
            <div className={this.state.opened ? 'modal show' : 'modal'} id="myModal">
                <div className="modal-dialog">
                    <div className="modal-content">
                        <div className="modal-header">
                            <h5 className="modal-title">{this.props.title}</h5>
                            <button type="button" className="close" onClick={this.cancel}>
                                <span aria-hidden="true">&times;</span>
                            </button>
                        </div>
                        <div className="modal-body">
                            <p>{this.props.message}</p>
                        </div>
                        <div className="modal-footer">
                            <button type="button" className="btn btn-primary" onClick={this.ok}>{ok.label}</button>
                            {cancel &&
                                <button type="button" className="btn btn-secondary" onClick={this.cancel}>{cancel.label}</button>}
                            
                        </div>
                    </div>
                </div>
            </div>
        );
    }
}