﻿let canvas,  //画布标签  绘图API
    stats,     //性能检测器
    camera,    //相机
    scene,     //场景
    renderer,  //渲染器
    group,     //物体组
    mouseX = 0,  //鼠标横向位置
    mouseY = 0,  //鼠标纵向位置
    windowHalfX = window.innerWidth / 2,  //视口大小的一般
    windowHalfY = window.innerHeight / 3; //视口大小的一半

init()  //构建地球
animate()  //使球旋转起来


function init() {
    // 获取canvas画布
    canvas = document.getElementById('webglcanvas')
    // stats性能检测器初始化
    stats = initStats();

    // 3D绘制
    // 相机
    camera = new THREE.PerspectiveCamera(60, window.innerWidth / window.innerHeight, 1, 2000)
    camera.position.z = 700  //相机的远近

    // 场景
    scene = new THREE.Scene()

    // 创建一个组合
    group = new THREE.Group()
    scene.add(group)  //将组合添加进场景中渲染

    // 地球 数学形状 贴图
    let loader = new THREE.TextureLoader()




    loader.load('~/img/mars_1k_color.jpg', function (texture) {
        // console.log(texture)
        let geometry = new THREE.SphereGeometry(200, 50, 20)  //形状
        let material = new THREE.MeshBasicMaterial({ map: texture })  //材质
        let mesh = new THREE.Mesh(geometry, material)  //物体
        group.add(mesh)
    })

    // 渲染器
    renderer = new THREE.WebGLRenderer({
        canvas: canvas,
        antialias: false, // true/false表示是否开启反锯齿,
        /*
        alpha: false,              // true/false 表示是否可以设置背景色透明,
        precision: 'highp',        // highp/mediump/lowp 表示着色精度选择,
        premultipliedAlpha: false, // true/false 表示是否可以设置像素深度（用来度量图像的分辨率）,
        maxLights: 3,              // 最大灯光数,
        stencil: false             // false/true 表示是否使用模板字体或图案
        */
    })
    // 指定渲染器宽高
    renderer.setSize(window.innerWidth, window.innerHeight)

    // 绑定鼠标移动事件，使星球移動
    document.addEventListener('mousemove', onDocumentMouseMove, true)

    // 窗口大小改变监听
    window.addEventListener('resize', onWindowResize, false)
}

// 监听鼠标移动方向， 从而确定地球南北半球
function onDocumentMouseMove(ev) {
    ev = ev || event
    mouseX = ev.clientX - windowHalfX
    mouseY = ev.clientY - windowHalfY
}

// 监听窗口大小， 从而根据窗口大小改变地球大小， 类似响应式
function onWindowResize() {
    windowHalfX = window.innerWidth / 2
    windowHalfY = window.innerHeight / 2
    camera.aspect = window.innerWidth / window.innerHeight
    camera.updateProjectionMatrix()
    renderer.setSize(window.innerWidth, window.innerHeight)
}

function animate() {
    // 请求运动帧
    requestAnimationFrame(animate)
    render()
}




// 地球旋转逻辑函数
function render() {
    // 更新性能监视器
    stats.update();
    camera.position.x += (mouseX - camera.position.x) * 0.05
    camera.position.y += (mouseX - camera.position.y) * 0.05
    // 拍摄角度， 可改变地球视角
    camera.lookAt(scene.position)
    // 地球自转速度
    group.rotation.y -= 0.02
    // 核心 递归调用
    renderer.render(scene, camera)
}

function initStats() {
    stats = new Stats();
    //设置统计模式
    stats.setMode(0); // 0: fps, 1: ms
    //统计信息显示在左上角
    stats.domElement.style.position = 'relative';
    stats.domElement.style.left = '10px';
    stats.domElement.style.top = '60px';
    //将统计对象添加到对应的<div>元素中
    document.getElementById("stats-output").appendChild(stats.domElement);
    return stats;
}

        // ecchat 数据可视化
        // 平面的世界是错误的， css  perspective:1000px  transform-style:perserve-3d
        // Camera Scene render(渲染容器) Light  ->  canvas





