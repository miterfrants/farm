/* Auto Generate */
// command line `node build-cache.js`
import {
    CheckInComponent
} from '../components/check-in/check-in.component.js';
import CheckInHTML from '../components/check-in/check-in.html';
import '../components/check-in/check-in.scss';

    CooperationComponent
} from '../components/cooperation/cooperation.component.js';
import CooperationHTML from '../components/cooperation/cooperation.html';
import '../components/cooperation/cooperation.scss';

    FeatureComponent
} from '../components/feature/feature.component.js';
import FeatureHTML from '../components/feature/feature.html';
import '../components/feature/feature.scss';

    FooterComponent
} from '../components/footer/footer.component.js';
import FooterHTML from '../components/footer/footer.html';
import '../components/footer/footer.scss';

    HeaderComponent
} from '../components/header/header.component.js';
import HeaderHTML from '../components/header/header.html';
import '../components/header/header.scss';

    HowToImplementAutopotComponent
} from '../components/how-to-implement-autopot/how-to-implement-autopot.component.js';
import HowToImplementAutopotHTML from '../components/how-to-implement-autopot/how-to-implement-autopot.html';
import '../components/how-to-implement-autopot/how-to-implement-autopot.scss';

    HowToImplementHygrometerComponent
} from '../components/how-to-implement-hygrometer/how-to-implement-hygrometer.component.js';
import HowToImplementHygrometerHTML from '../components/how-to-implement-hygrometer/how-to-implement-hygrometer.html';
import '../components/how-to-implement-hygrometer/how-to-implement-hygrometer.scss';

    HowToIntegrateGoogleNestComponent
} from '../components/how-to-integrate-google-nest/how-to-integrate-google-nest.component.js';
import HowToIntegrateGoogleNestHTML from '../components/how-to-integrate-google-nest/how-to-integrate-google-nest.html';
import '../components/how-to-integrate-google-nest/how-to-integrate-google-nest.scss';

    HowToStartComponent
} from '../components/how-to-start/how-to-start.component.js';
import HowToStartHTML from '../components/how-to-start/how-to-start.html';
import '../components/how-to-start/how-to-start.scss';

    HowToUseComponent
} from '../components/how-to-use/how-to-use.component.js';
import HowToUseHTML from '../components/how-to-use/how-to-use.html';
import '../components/how-to-use/how-to-use.scss';

    LineUsComponent
} from '../components/line-us/line-us.component.js';
import LineUsHTML from '../components/line-us/line-us.html';
import '../components/line-us/line-us.scss';

    PricingPlanComponent
} from '../components/pricing-plan/pricing-plan.component.js';
import PricingPlanHTML from '../components/pricing-plan/pricing-plan.html';
import '../components/pricing-plan/pricing-plan.scss';

export const Cacher = {
    buildCache: () => {
        window.APP_CONFIG = APP_CONFIG;
        window.SwimAppComponents = window.SwimAppComponents || [];
        window.SwimAppLoaderCache = window.SwimAppLoaderCache || [];
        window.SwimAppStylesheet.push(`${APP_CONFIG.FRONT_END_PREFIX}/components/check-in/check-in.css`);
    }
}