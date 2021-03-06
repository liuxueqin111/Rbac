import Vue from 'vue'
import VueRouter from 'vue-router'
import HomeView from '../views/HomeView.vue'

Vue.use(VueRouter)

const routes = [
  {
    path: '/',
    name: 'Home',
    component: () => import('../views/Home.vue'),
    children:[
      {path: '/list',
      name: 'Home',
      component: () => import('../views/list.vue')},
      {path: '/add',
      name: 'Home',
      component: () => import('../views/add.vue')},
      {path: '/Edit',
      name: 'Home',
      component: () => import('../views/Edit.vue')},
      ]
  },
  {
    path: '/about',
    name: 'about',
    // route level code-splitting
    // this generates a separate chunk (about.[hash].js) for this route
    // which is lazy-loaded when the route is visited.
    component: () => import(/* webpackChunkName: "about" */ '../views/AboutView.vue')
  },
  {
    path: '/Login',
    name: 'Home',
    component: () => import('../views/Admin/Login.vue')
  },
]

const router = new VueRouter({
  routes
})

export default router
