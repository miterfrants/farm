import {
    RoutingController
} from '../swim/routing-controller.js';
import { Toaster } from '../util/toaster.js';
import { CookieUtil } from '../util/cookie.js';
import { RESPONSE_STATUS } from '../constants.js';
import { CUSTOM_ERROR_TYPE } from '../util/custom-error.js';
import { UniversalDataService } from '../dataservices/universal.dataservice.js';

export class MasterController extends RoutingController {
    constructor (elHTML, parentController, args, context) {
        super(elHTML, parentController, args, context);
        this.Toaster = Toaster;
    }

    static get id () {
        return 'MasterController';
    }

    async render () {

        await super.render({
        });
    }

  
}
