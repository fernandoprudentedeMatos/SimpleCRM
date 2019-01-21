import * as React from 'react';
import { CostumerForm } from './CostumerForm';
import { CostumerList } from './CostumerList';
import { RouteComponentProps } from "react-router-dom";
import { Modal } from '../common/Modal';
import CostumerService from '../../services/CostumerService';

interface ICostumerState {
    data: any[];
    showDeleteConfirm: boolean
    deleteConfirmParam?: any
}

export class Costumer extends React.Component<RouteComponentProps<{}>, ICostumerState> {
    constructor() {
        super();
        this.state = {
            data: [],
            showDeleteConfirm: false
        }

        this.edit = this.edit.bind(this);
        this.saveNew = this.saveNew.bind(this);
        this.setData = this.setData.bind(this);
        this.editSave = this.editSave.bind(this);
        this.editCancel = this.editCancel.bind(this);
        this.deletePreConfirm = this.deletePreConfirm.bind(this);
        this.deleteConfirm = this.deleteConfirm.bind(this);
    }

    private setData(data: any) {
        this.setState({ data })
    }

    componentDidMount() {
        this.loadData();
    }

    loadData() {
        return CostumerService.getAll().then(data => this.setData(data));
    }

    edit(index: number) {
        const data = [...this.state.data];
        data[index].editing = true;
        this.setData(data);
    }

    editSave(updatedModel: any, index: any) {

        return CostumerService.save(updatedModel).then(() => {
            const data = [...this.state.data];
            data[index] = updatedModel;
            data[index].editing = false;
            this.setData(data);
        });
    }

    editCancel(index: any) {
        const data = [...this.state.data];
        data[index].editing = false;
        this.setData(data);
    }

    saveNew(model: any) {
        return CostumerService.save(model)
            .then(() => {
                this.loadData();
            })
    }

    deletePreConfirm(index: number) {
        this.setState({
            deleteConfirmParam: index,
            showDeleteConfirm: true
        })
    }

    deleteConfirm(param: any) {
        const data = [...this.state.data];
        const id = data[param].id;

        this.setState({ showDeleteConfirm: false });

        CostumerService.delete(id).then(res => {
            data.splice(param, 1);
            this.setData(data);            
        });
    }

    public render(){
        return (<div>
            <h1>Clientes</h1>
            <CostumerForm cancel={() => { }} save={this.saveNew} />
            <CostumerList delete={this.deletePreConfirm} editSave={this.editSave} edit={this.edit} editCancel={this.editCancel} data={this.state.data} />
            <Modal
                message={'Deseja realmente excluir?'}
                buttons={{
                    ok: { label: 'OK', callback: this.deleteConfirm },
                    cancel: { label: 'Cancelar', callback: () => { this.setState({ showDeleteConfirm: false }) } }
                }}
                title={'Atenção!'}
                show={this.state.showDeleteConfirm}
                param={this.state.deleteConfirmParam}
            />
        </div>);
    }
}
