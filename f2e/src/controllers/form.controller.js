import { LogDataService } from '../dataservices/log.dataservice.js';
import {
    RoutingController
} from '../swim/routing-controller.js';
import { Toaster } from '../util/toaster.js';

export class FormController extends RoutingController {
    async render () {
        const isCreate = location.pathname.endsWith('create/');
        const now = new Date();
        await super.render({
            ...this.args.log,
            createdAt: isCreate ? `${now.getFullYear()}-${now.getMonth()+1}-${now.getDate()}`  :this.args.log.createdAt.split('T')[0]
        });
    }

    async postRender(){
        await super.postRender();
        const currentState = this.args.log ? JSON.parse(this.args.log.currentState) : [];
        this.elHTML.querySelectorAll('[data-field="currentState"]>option').forEach(item=> {
            if(currentState.indexOf(Number(item.value)) !== -1) {
                item.selected = true;
            }
        })
    }

    async save(event) {
        const elButton = event.currentTarget;
        elButton.setAttribute('disabled','disabled');
        const data = this.elHTML.collectFormData();
        const currentState = [];
        this.elHTML.querySelectorAll('[data-field="currentState"]>option').forEach(item=>{
            if(item.selected) {
                currentState.push(Number(item.value));
            }
        });

        data.currentState = JSON.stringify(currentState);
        const isCreate = location.pathname.endsWith('create/');
        const action = isCreate ? LogDataService.Create : LogDataService.Update;
        const resp = (await action(this.args.id, this.args.logId, data));
        elButton.removeAttribute('disabled');
        if(!isCreate && resp.status!=="OK") {
            Toaster.popup(Toaster.TYPE.ERROR, resp.data.message);
        } else if(!isCreate && resp.status === 'OK') {
            Toaster.popup(Toaster.TYPE.INFO, 'Updated');
        } else if(isCreate && resp.data.id) {
            history.pushState({},"",`/strawberries/${resp.data.strawberryId}/logs/${resp.data.id}/`);
        } else {
            Toaster.popup(Toaster.TYPE.ERROR, resp.data.message);
        }
    }
}
