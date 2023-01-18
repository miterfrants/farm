import { APP_CONFIG } from '../config.js';
import { LogDataService } from '../dataservices/log.dataservice.js';
import {
    RoutingController
} from '../swim/routing-controller.js';

export class StrawberryListController extends RoutingController {
    async render () {
        const strawberries  = this.args.strawberries;
        
        strawberries.forEach((item)=>{
            item.isDeathStyle = 'btn-grey-500 opacity-25';
            if(!item.currentState?.includes(-1)){
                item.isDeathStyle = ''
                item.isDeath = 'd-none';
            }
            if(!item.currentState?.includes(3)){
                item.isSick = 'd-none';
            }
        });

        await super.render({
            strawberries: strawberries
        });
    }
}
