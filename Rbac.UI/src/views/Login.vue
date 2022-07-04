<template>
  <el-form
    :model="ruleForm"
    :rules="rules"
    ref="ruleForm"
    label-width="100px"
    class="demo-ruleForm"
  >
    <el-form-item label="用户名">
      <el-input v-model="ruleForm.UserName"></el-input>
    </el-form-item>
    <el-form-item label="密码">
      <el-input v-model="ruleForm.Password"></el-input>
    </el-form-item>
    <el-form-item>
      <el-button type="primary" @click="submitForm('ruleForm')"
        >立即创建</el-button
      >
      <el-button @click="resetForm('ruleForm')">重置</el-button>
    </el-form-item>
  </el-form>
</template>
<script>
export default {
  data() {
    return {
      ruleForm: {
        UserName: "",
        Password: "",
        Email: "",
        LastLoginTime: "",
        LastLoginIP: "",
        IsLock: "",
        CreateTime: "",
        CreateId: "",
        IsDelete: false,
      },
      rules: {
        UserName: [
          { required: true, message: "请输入用户名", trigger: "blur" },
          { min: 3, max: 5, message: "长度在 3 到 5 个字符", trigger: "blur" },
        ],
        Password: [{ required: true, message: "请输入密码", trigger: "blur" }],
      },
    };
  },
  methods: {
    submitForm(formName) {
      this.$refs[formName].validate((valid) => {
        if (valid) {
          this.$axios
            .post("https://localhost:44340/api/Admin/Login", this.ruleForm)
            .then((res) => {
              debugger;
              if (res.data.msg == "登录成功") {
                alert("成功");
              } else {
                if (confirm("您还没有注册是否注册")) {
                    this.ZhuCe();
                }
              }
            });
        } else {
          console.log("error submit!!");
          return false;
        }
      });
    },
    ZhuCe() {
      let form = {
          UserName:this.ruleForm.UserName,
          Password:this.ruleForm.Password,
      }
      this.$axios
        .post("https://localhost:44340/api/Admin/Register",form)
        .then((res) => {
          alert(res.data.msg);
        });
    },
    resetForm(formName) {
      this.$refs[formName].resetFields();
    },
  },
};
</script>