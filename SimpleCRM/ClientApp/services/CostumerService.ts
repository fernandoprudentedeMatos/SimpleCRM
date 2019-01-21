import MessageHandler from './MessageHandler';
import httpService from './HttpService';
const costumerHttpService = httpService('api/costumers');
import { Promise } from 'es6-promise';

export default {
    save: (model: any) => {

        //-- Eder, validação bem mal feita mesmo e codigo bem mais ou menos, mas da pra se ter uma ideia .. rsrs
        if (!model.nome) {
            MessageHandler.showMessage('Preencha o nome do cliente');
            return Promise.reject('form error');
        }
        if (!model.telefone) {
            MessageHandler.showMessage('Preencha o telefone do cliente');
            return Promise.reject('form error');
        }
        if (!model.email) {
            MessageHandler.showMessage('Preencha o email do cliente');
            return Promise.reject('form error');
        }         
        if (!model.endereco) {
            MessageHandler.showMessage('Preencha o endereço do cliente');
            return Promise.reject('form error');
        }            

        if (!model.id)
            return costumerHttpService.insert(model);
        else
            return costumerHttpService.update(model);
    },
    delete: (id: string) => {
        return costumerHttpService.delete(id);
    },
    getAll: () => {
        return costumerHttpService.getAll();
    }
}