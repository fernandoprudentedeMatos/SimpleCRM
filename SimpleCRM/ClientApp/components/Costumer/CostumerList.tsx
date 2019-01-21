import * as React from 'react';
import { CostumerForm } from './CostumerForm';

interface CostumerListState {

}

interface CostumerListProps {
    data: any[],
    edit(index: number): void
    editSave(updateModel: any, index: number): Promise<any>
    editCancel(index: number): void
    delete(index: number): void
}

export const CostumerList = (props: CostumerListProps) => {    
    return <div>  
        <div className="table-responsive">
            {props.data.length === 0 ? ' ' :
                <table className="table">
                    <tr>
                        <th>Nome</th>
                        <th>Telefone</th>
                        <th>E-mail</th>                        
                        <th>Endereço</th>
                        <th></th>
                    </tr>
                    {props.data
                        .map((c, index) => c.editing ?
                            <tr key={index}>
                                <td>{' '}</td>
                                <td colSpan={3}>
                                    <div className="card">
                                        <div className="card-body">
                                            <CostumerForm cancel={() => { props.editCancel(index) }} modelToChange={c} save={(model) => { return props.editSave(model, index) }} />
                                        </div>
                                    </div>
                                </td>
                                <td>{' '}</td>
                            </tr> :
                            <tr key={index}>
                                <td>{c.nome}</td>
                                <td>{c.telefone}</td>
                                <td>{c.email}</td>                                
                                <td>{c.endereco}</td>
                                <td>
                                    <button className="btn btn-default" onClick={() => { props.edit(index) }}>Editar</button> {' '}
                                    <button className="btn btn-danger" onClick={() => props.delete(index)}>Excluir</button> 
                                    
                                </td>
                            </tr>
                        )}
                </table>}
        </div>
        </div>;
}