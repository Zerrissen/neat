import type { PropType } from 'vue';
import { omit } from '../../utils';
import type { VerticalNavigationLink } from '../../types';
declare const _default: import("vue").DefineComponent<{
    links: {
        type: PropType<VerticalNavigationLink[]>;
        default: () => never[];
    };
    class: {
        type: PropType<any>;
        default: undefined;
    };
    ui: {
        type: PropType<Partial<any>>;
        default: undefined;
    };
}, {
    ui: import("vue").ComputedRef<any>;
    attrs: import("vue").ComputedRef<Pick<{
        [x: string]: unknown;
    }, string>>;
    omit: typeof omit;
}, unknown, {}, {}, import("vue").ComponentOptionsMixin, import("vue").ComponentOptionsMixin, {}, string, import("vue").VNodeProps & import("vue").AllowedComponentProps & import("vue").ComponentCustomProps, Readonly<import("vue").ExtractPropTypes<{
    links: {
        type: PropType<VerticalNavigationLink[]>;
        default: () => never[];
    };
    class: {
        type: PropType<any>;
        default: undefined;
    };
    ui: {
        type: PropType<Partial<any>>;
        default: undefined;
    };
}>>, {
    ui: Partial<any>;
    class: any;
    links: VerticalNavigationLink[];
}, {}>;
export default _default;
