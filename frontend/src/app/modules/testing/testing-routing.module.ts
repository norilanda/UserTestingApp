import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { TestsPageComponent } from './components/tests-page/tests-page.component';
import { PassTestComponent } from './components/pass-test/pass-test.component';

const routes: Routes = [
  {
    path: 'pass-test/:id',
    component: PassTestComponent,
  },
  {
    path: '',
    component: TestsPageComponent,
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class TestingRoutingModule {}
