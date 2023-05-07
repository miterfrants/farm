import { RESPONSE_STATUS } from '../constants.js';
import { FilesService } from '../dataservices/file.service.js';
import { MlDataService } from '../dataservices/ml-raw.dataservice.js';
import {
    RoutingController
} from '../swim/routing-controller.js';
import { Toaster } from '../util/toaster.js';
export class MlRawController extends RoutingController {
    async render () {
        console.log(this.args.diseases);
        await super.render({
            diseases: this.args.diseases,
            fileName: '',
            currentState: '',
            buttonDisabled: 'disabled',
        });
    }

    async postRender(){
        await super.postRender();
    }

    updateFormState() {
        if(this.pageVariable.fileName!=='' && this.pageVariable.currentState !=='')    {
            
            this.pageVariable.buttonDisabled='';
        }
    }

    updateState(e) {
        this.pageVariable.currentState = e.currentTarget.value;
        this.updateFormState();
    }

    async uploadFile (e) {
        if (!e.target.files || e.target.files.length === 0) {
            return;
        };
        const elInput = e.currentTarget;
        const resp = await FilesService.Upload({
            fileName: elInput.files[0].name
        }, e.target.files);

        if (!resp.data.fileName) {
            Toaster.popup(Toaster.TYPE.ERROR, resp.data.message);
            return;
        }

        this.pageVariable.fileName = resp.data.fileName
        e.target.value = '';
        this.updateFormState();
        Toaster.popup(Toaster.TYPE.INFO, '上傳成功');
    }

    async createRaw() {
        const resp = await MlDataService.Create({
            fileName: this.pageVariable.fileName,
            disease: Number(this.pageVariable.currentState)
        })
        if (resp.status !== RESPONSE_STATUS.OK) {
            Toaster.popup(Toaster.TYPE.ERROR, resp.data.message);
            return;
        }
        this.pageVariable.buttonDisabled='disabled';
        this.pageVariable.currentState = '';
        this.pageVariable.fileName = '';
        this.updateFormState();

        Toaster.popup(Toaster.TYPE.INFO, '建立成功');
    }


}
