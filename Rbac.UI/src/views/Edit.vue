<template>
<div>
<el-form ref="form" :model="form" label-width="80px">
  <el-form-item label="">
      <el-cascader
       v-model="form.ParentId"
    :options="options"
    :props="{ checkStrictly: true }"
    ref="getParentId"
    clearable></el-cascader>
  </el-form-item>
  <el-form-item label="菜单名称">
    <el-input v-model="form.menuname"></el-input>
  </el-form-item>
  <el-form-item label="链接">
    <el-input v-model="form.linkurl"></el-input>
  </el-form-item>
  <el-form-item>
    <el-button type="primary" @click="onSubmit">保存</el-button>
    <el-button>取消</el-button>
  </el-form-item>
</el-form>
</div>
</template>
<script>
  export default {
    props:["formdate"],
    data() {
      return {
        options:[],
        form: {
          menuId:"",
          menuname: '',
          ParentId:'',
          linkurl: '',
        }
      }
    },
    methods: {
      onSubmit() {
        debugger
        this.form.ParentId = this.$refs["getParentId"].getCheckedNodes()[0].value;
        this.$axios.post('https://localhost:44340/api/VUE/Edit',this.form)
        .then(res =>{
            if(res.data > 0)
            {
                this.$message.success('修改成功');
                this.$emit("Edit",true);
            }
        })
      },
      GetShow(){
        debugger
            this.form.menuId = this.formdate.menuId;
            this.form.menuname=this.formdate.menuName;
            this.form.linkurl=this.formdate.linkurl;
            this.form.ParentId=this.formdate.menuId;
        this.$axios.get('https://localhost:44340/api/VUE/GetList')
        .then(res =>{
            var reg = new RegExp('\\,"children":\\[]',"g");
        this.options = JSON.parse(JSON.stringify(res.data).replace(reg,""));
        })
      }
    },
    created(){
        this.GetShow();
    },
    watch:{
        formdate(val)
        {
          this.GetShow();
        }
    },
  }
</script>