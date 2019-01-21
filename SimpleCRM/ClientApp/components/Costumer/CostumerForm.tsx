import * as React from 'react';

interface CostumerFormState {
    model: any
}

interface costumerFormProps {
    save(model: any): Promise<any>
    cancel(): void
    modelToChange?: any
}

export class CostumerForm extends React.Component<costumerFormProps, CostumerFormState> {
    constructor(props: costumerFormProps) {
        super(props);
        this.state = {
            model: props.modelToChange || {
                nome: '',
                telefone: '',
                email: '',
                endereco: ''
            }
        }

        this.modelChange = this.modelChange.bind(this);
        this.save = this.save.bind(this);
        this.resetForm = this.resetForm.bind(this);
    }

    resetForm() {
        this.setState({
            model: {
                nome: '',
                telefone: '',
                email: '',
                endereco: ''
            }
        });

        this.props.cancel();
    }

    save() {
        this.props.save(this.state.model).then(() => {
            this.resetForm();
        });
    }

    modelChange(event: any) {
        this.setState({
            model: {
                ...this.state.model, [event.target.name]: event.target.value
            }
        })
    }

    public render() {
        return <div>
            <div className="form-group">
                <label className="control-label">Nome</label>
                <input maxLength={120} className="form-control" type="text" name="nome" value={this.state.model.nome} onChange={this.modelChange} />
            </div>
            <div className="form-group">
                <label>Telefone</label>
                <input maxLength={15} className="form-control" type="text" name="telefone" value={this.state.model.telefone} onChange={this.modelChange} />
            </div>
            <div className="form-group">
                <label>E-mail</label>
                <input maxLength={70} className="form-control" type="text" name="email" value={this.state.model.email} onChange={this.modelChange} />
            </div>
            <div className="form-group">
                <label>Endereço</label>
                <textarea className="form-control" type="text" name="endereco" value={this.state.model.endereco} onChange={this.modelChange} />
            </div>
            <button onClick={this.save} className="btn btn-primary">Salvar</button> {' '}
            <button onClick={this.resetForm} className="btn btn-danger">Cancelar</button>
        </div>
    }
}