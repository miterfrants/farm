import { APP_CONFIG } from '../config.js';
import {
    RoutingController
} from '../swim/routing-controller.js';

export class StrawberryListController extends RoutingController {
    async render () {
        await super.render({
            strawberries: this.args.strawberries
        });
    }
}
