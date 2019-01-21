import { Promise } from 'es6-promise';
import MessageHandler from './MessageHandler';

export default function (apiUrl: string) {
    const retornaResultado = (res: Response): Promise<any> => {
        return res
            .json()
            .catch(err => res);
    }

    const trataErro = (res: Response) => {
        switch (res.status) {
            case 409:
                return res.text().then(data => {
                    MessageHandler.showMessage(data);
                    return Promise.reject(data);
                })

            case 500:
                MessageHandler.showMessage('Erro Crítico Ocorreu!');
                return Promise.reject('erro crítico ocorreu');
            default:
                return res;
        }
    }

    return {
        getAll: (): Promise<Response> => {
            return fetch(apiUrl, {
                //: se tivesse autorização por Token jwt: headers: { 'authorization': `Bearer ${Context.GetToken()}` }
            })
                .then(trataErro)
            .then(retornaResultado)
        },
        insert: (model: any): Promise<Response> => {
            return fetch(apiUrl, {
                headers: {
                    'Content-Type': 'application/json'
                },
                method: 'POST',
                body: JSON.stringify(model)
            })
                .then(trataErro)
                .then(retornaResultado);
        },
        update: (model: any): Promise<Response> => {
            return fetch(apiUrl, {
                headers: {
                    'Content-Type': 'application/json'
                },
                method: 'PUT',
                body: JSON.stringify(model)
            })
                .then(trataErro)
                .then(retornaResultado);
        },
        delete: (id: string) => {
            return fetch(`${apiUrl}/${id}`, {
                method: 'DELETE'
            })
                .then(trataErro)
            .then(retornaResultado);
        }
    }
}