/* istanbul ignore file */
/* tslint:disable */
/* eslint-disable */

import type { ChoiceQuestionCategory } from './ChoiceQuestionCategory';
import type { ChoiceQuestionOptionDto } from './ChoiceQuestionOptionDto';
import type { ChoiceQuestionOptionIndex } from './ChoiceQuestionOptionIndex';

export type ChoiceQuestionDto = {
    id?: string;
    creationTime?: string;
    creatorId?: string | null;
    lastModificationTime?: string | null;
    lastModifierId?: string | null;
    category?: ChoiceQuestionCategory;
    title?: string | null;
    options?: Array<ChoiceQuestionOptionDto> | null;
    comment?: string | null;
    tenantId?: string | null;
    answer?: ChoiceQuestionOptionIndex;
};
