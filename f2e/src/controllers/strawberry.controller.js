import { APP_CONFIG } from '../config.js';
import {
    RoutingController
} from '../swim/routing-controller.js';

export class StrawberryController extends RoutingController {
    async render () {
        await super.render({
            ...this.args.strawberry,
            strawberryId: this.args.strawberry.id,
            logs: this.args.logs.map(item=>{
                return {
                    ...item,
                    createdAt: item.createdAt.split('T')[0]
                }
            })
        });
    }
}
